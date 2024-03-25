using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public Animator animator;
    public AudioSource gunFireSound;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate; 
            Shoot();
            gunFireSound.Play();
            animator.SetTrigger("Shoot");
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
        }
    }
}


