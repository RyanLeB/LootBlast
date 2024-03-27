using System.Collections;
using UnityEngine;

public class TriggerCountdown : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public float countdownTime = 22.5f; 

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartCountdown(countdownTime));
    }

    private IEnumerator StartCountdown(float countdownValue)
    {
        yield return new WaitForSeconds(countdownValue);
        object1.SetActive(true);
        object2.SetActive(true);
    }
}
