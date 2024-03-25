using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TMP_Text healthText;
    public DamageEffect damageEffect;

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    private void Update()
    {
        healthText.text = "Health: " + currentHealth + " / 100";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        damageEffect.ShowDamageEffect();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Handle player death here
        Debug.Log("Player died!");
    }
}