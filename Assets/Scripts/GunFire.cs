using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GunFire : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;
    public int maxAmmo = 999;
    private int currentAmmo = 10;
    
    public TMP_Text ammoGainedText;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public Animator animator;
    public AudioSource gunFireSound;
    public AudioSource reloadSound;

    private void Start()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate; 
            currentAmmo--;
            Shoot();
            animator.SetTrigger("Shoot");
            gunFireSound.Play();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name); 

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact,2f);
            UpdateAmmoUI();
        }
    }

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        reloadSound.Play();
        ammoGainedText.text = "+" + amount.ToString();
        UpdateAmmoUI();
        StartCoroutine(FadeAmmoGainedText());

    }

    public void UpdateAmmoUI()
    {
        GameManager.Instance.ammoText.text = "Ammo: " + currentAmmo.ToString();
    }

    IEnumerator FadeAmmoGainedText()
    {
        
        Color color = ammoGainedText.color;
        color.a = 1f;
        ammoGainedText.color = color;

        
        yield return new WaitForSeconds(0.5f);

        
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime;
            ammoGainedText.color = color;
            yield return null;
        }

        
        color.a = 0f;
        ammoGainedText.color = color;
    }

    public bool IsShooting()
    {
        return Input.GetButton("Fire1") && Time.time >= nextTimeToFire;
    }
}


