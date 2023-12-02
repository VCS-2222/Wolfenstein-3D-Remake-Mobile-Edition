using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GermanTrooperAI : MonoBehaviour
{
    [Header("Important Components")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] GameObject thingToSpawnOnDeath;
    [SerializeField] GameObject thingToSpawnIfSpecialDeath;
    public GameObject player;

    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject dyingCounterpart;

    [Header("Variables")]
    [SerializeField] float generalSpeed;
    [SerializeField] float angularSpeed;
    [SerializeField] bool hasPath;
    [SerializeField] bool isIdle;
    [SerializeField] int health;
    [SerializeField] int scoreWorth;
    [SerializeField] float visionSight;
    [SerializeField] bool hasSeenPlayer;

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
        Chase();
    }

    private void FixedUpdate()
    {
        if (hasSeenPlayer)
            return;

        VisionPerAngle(90);
        VisionPerAngle(75);
        VisionPerAngle(60);
        VisionPerAngle(30);
        VisionPerAngle(15);
        VisionPerAngle(0);
        VisionPerAngle(-15);
        VisionPerAngle(-30);
        VisionPerAngle(-60);
        VisionPerAngle(-75);
        VisionPerAngle(-90);
    }

    void VisionPerAngle(float angleIn)
    {
        Vector3 start = transform.position + new Vector3(0, 1f, 0);
        Quaternion angle = Quaternion.Euler(0, angleIn, 0);

        Debug.DrawRay(start, angle * transform.forward, Color.red);

        Physics.Raycast(start, angle * transform.forward, out RaycastHit hit, visionSight);

        if (hit.transform.gameObject.tag == "Player")
        {
            player = hit.transform.gameObject;
            hasSeenPlayer = true;
        }
    }

    void Chase()
    {
        if (hasSeenPlayer)
        {
            if (isIdle)
                return;

            agent.destination = player.transform.position;

            float findDistance = Vector3.Distance(this.transform.position, player.transform.position);

            if(findDistance <= 6)
            {
                StartCoroutine(Shooting());
            }
        }
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

    IEnumerator Shooting()
    {
        isIdle = true;
        agent.isStopped = true;
        animator.SetBool("Aim", true);
        this.transform.LookAt(player.transform);

        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Aim", false);

        animator.SetTrigger("Shoot");

        RaycastHit hit;
        Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, 10);

        print(hit.collider.gameObject.name);

        if(hit.collider.tag == "Player")
        {
            hit.collider.GetComponent<PlayerStats>().TakeDamage(14);
        }
        else
        {

        }

        yield return new WaitForSeconds(1f);

        agent.isStopped = false;
        agent.destination = player.transform.position;
        isIdle = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            PlayerStats.instance.AddKills();
            PlayerStats.instance.AddScore(scoreWorth);
            if (PlayerStats.instance.hasPistol)
            {
                Instantiate(thingToSpawnOnDeath, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(thingToSpawnIfSpecialDeath, this.transform.position, Quaternion.identity);
            }

            Instantiate(dyingCounterpart, this.transform.position, this.transform.rotation);

            Destroy(gameObject);
        }
    }
}