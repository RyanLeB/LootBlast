using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 10;
    public GunFire gunFire;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (gunFire != null)
            {
                gunFire.AddAmmo(ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
