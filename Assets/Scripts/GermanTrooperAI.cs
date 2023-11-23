using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GermanTrooperAI : MonoBehaviour
{
    [Header("Important Components")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;

    [Header("Variables")]
    [SerializeField] float generalSpeed;
    [SerializeField] float angularSpeed;
    [SerializeField] bool hasPath;
    [SerializeField] bool isIdle;
    [SerializeField] int health;
    [SerializeField] int scoreWorth;

    [Header("Path Settings")]
    [SerializeField] List<Transform> path = new List<Transform>();
    [SerializeField] int currentPathPoint;

    private void Awake()
    {
        health = 100;
        agent.speed = generalSpeed;
        agent.angularSpeed = angularSpeed;
    }

    private void Update()
    {
        DoPath();
        DoMovementAnimation();
    }

    void DoPath()
    {
        if (!hasPath)
            return;

        if (isIdle)
            return;

        if (agent.remainingDistance < 1)
        {
            StartCoroutine(StayAtPointForABit());
        }
    }

    IEnumerator StayAtPointForABit()
    {
        isIdle = true;

        yield return new WaitForSeconds(4f);

        isIdle = false;
        currentPathPoint++;
        if (currentPathPoint > path.Count)
        {
            currentPathPoint = 0;
            agent.SetDestination(path[currentPathPoint].position);
        }
        else
        {
            agent.SetDestination(path[currentPathPoint].position);
        }
    }

    void DoMovementAnimation()
    {
        if(agent.velocity.magnitude > 1f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            EndGameManager.instance.kills++;
            PlayerStats.instance.AddScore(scoreWorth);
            Destroy(gameObject);
        }
    }
}