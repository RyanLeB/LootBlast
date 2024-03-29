using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{

    public float health = 50f;
    private bool isDead = false;
    public GameObject targetPrefab;
    public int scoreValue = 50;
    public Animator animator;
    public NavMeshAgent agent;
    public AudioSource hitSound;

    private void Start()
    {
        if (!isDead)  // Check if the target is not dead before instantiating
            InstantiateTarget();
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;
        animator.SetTrigger("Hit");
        
        health -= amount;
        if (health <= 0f)
        {
            isDead = true;
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Search", false);
            animator.SetTrigger("Die");
            
            GameManager.Instance.AddScore(scoreValue);

            agent.enabled = false;
            
            if (gameObject.CompareTag("Boss"))
            {
                EnemyStateAI.bossesDefeated++;
            }
            StartCoroutine(DelayedDeactivate(2f));

        }
    }
    
    private void InstantiateTarget()
    {
        if (targetPrefab == null)
        {
            targetPrefab = Instantiate(gameObject, transform.position, transform.rotation);
        }
    }

    private IEnumerator DelayedDeactivate(float delay)
    {
            hitSound.Play();
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }



}
