using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] GameObject secretDoor;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform startPoint;
    [SerializeField] float speed;
    public bool isOpened;
    float elapsedTime;

    public void OpenSecretDoor()
    {
        if (isOpened)
            return;

        PlayerStats.instance.AddSecrets();
        isOpened = true;
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        while (true)
        {
            elapsedTime += speed * Time.deltaTime;

            secretDoor.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, elapsedTime);

            yield return new WaitForSeconds(0.01f);

            if (secretDoor.transform.position == endPoint.position)
            {
                break;
            }
        }
    }
}
