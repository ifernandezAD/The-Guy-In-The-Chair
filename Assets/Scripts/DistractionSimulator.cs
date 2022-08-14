using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionSimulator : MonoBehaviour
{

    public GameObject distractionImage;
    public bool gameActive;
    public float waitingTime;
    public float distractionTime;

    private void OnEnable()
    {
        StartCoroutine("RandomDistraction");
    }

    IEnumerator RandomDistraction()
    {
        while (gameActive)
        {
            waitingTime = Random.Range(30, 90);
            distractionTime = Random.Range(10, 20);
            yield return new WaitForSeconds(waitingTime);
            distractionImage.SetActive(true);
            yield return new WaitForSeconds(distractionTime);
            distractionImage.SetActive(false);
        }
    }


}
