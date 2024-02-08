using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    private bool isDead = false;
    public GameObject targetPrefab;


    private void Start()
    {
        if (!isDead)  // Check if the target is not dead before instantiating
            InstantiateTarget();
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        health -= amount;
        if (health <= 0f)
        {
            isDead = true;
            gameObject.SetActive(false);
            

        }
    }
    
    private void InstantiateTarget()
    {
        if (targetPrefab == null)
        {
            targetPrefab = Instantiate(gameObject, transform.position, transform.rotation);
        }
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        health = 50f; // Reset health
        InstantiateTarget();
        gameObject.SetActive(true);
        isDead = false;
    }

    
    
}
