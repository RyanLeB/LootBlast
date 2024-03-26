using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10; 
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            
            GameManager.Instance.AddScore(scoreValue);
            collectSound.Play();
            
            Destroy(gameObject);
            
        }
    }
}
