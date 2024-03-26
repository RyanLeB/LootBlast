using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healAmount = 20; 
    public AudioSource healSound;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                healSound.Play();
                
                Destroy(gameObject);

                
            }
        }
    }
}
