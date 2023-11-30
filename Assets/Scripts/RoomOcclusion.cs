using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOcclusion : MonoBehaviour
{
    [SerializeField] Vector3 boxHalfExtends;

    public bool hasPlayerInside;
    public bool allDoorsClosed;

    public List<GameObject> theRoom;

    public Door[] doors;

    private void Start()
    {
        DisableRenderers();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StartRoomCheck());
        }
    }

    IEnumerator StartRoomCheck()
    {
        while (true)
        {
            openedDoors = 0;
            CheckPerimeter();

            if (!hasPlayerInside && allDoorsClosed)
            {
                DisableRenderers();
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                hasPlayerInside = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CheckPerimeter();
            EnableRenderers();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(this.transform.position, boxHalfExtends * 2);
    }

    void CheckPerimeter()
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, boxHalfExtends, Quaternion.identity);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Player")
            {
                hasPlayerInside = true;
            }
        }
    }

    [SerializeField] int openedDoors;

    void VerifyDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].isOpened)
            {
                openedDoors++;
            }
        }

        if (openedDoors == 0)
        {
            allDoorsClosed = true;
        }
    }

    void DisableRenderers()
    {
        for (int i = 0; i < theRoom.Count; i++)
        {
            if (theRoom[i].GetComponent<Renderer>() != null)
            {
                theRoom[i].GetComponent<Renderer>().enabled = false;
            }

            if (theRoom[i].GetComponentInChildren<Renderer>() != null)
            {
                theRoom[i].GetComponentInChildren<Renderer>().enabled = false;
            }

            if (theRoom[i].GetComponentInChildren<Light>() != null)
            {
                theRoom[i].GetComponentInChildren<Light>().enabled = false;
            }
        }
    }

    void EnableRenderers()
    {
        for (int i = 0; i < theRoom.Count; i++)
        {
            if (theRoom[i].GetComponent<Renderer>() != null)
            {
                theRoom[i].GetComponent<Renderer>().enabled = true;
            }

            if (theRoom[i].GetComponentInChildren<Renderer>() != null)
            {
                theRoom[i].GetComponentInChildren<Renderer>().enabled = true;
            }

            if (theRoom[i].GetComponentInChildren<Light>() != null)
            {
                theRoom[i].GetComponentInChildren<Light>().enabled = true;
            }
        }
    }
}