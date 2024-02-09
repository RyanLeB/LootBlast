using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    private FPSController controller;
    public Transform cam;
    public Transform gunTip;
    public LineRenderer lr;
    public LayerMask whatsGrapplable;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelay;
    public float overShootYAxis;

    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grappleCooldown;
    private float grappleTimer;

    [Header("Input")]
    public KeyCode grappleKey = KeyCode.Q;

    private bool grappling;

    private void Start()
    {
        controller = GetComponent<FPSController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(grappleKey))
        {
            StartGrapple();
        }  
        if (grappleTimer > 0)
        {
            grappleTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartGrapple()
    {
        if (grappleTimer > 0) return;
        
        

        grappling = true;

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatsGrapplable)) 
        {
            grapplePoint = hit.point;
            Invoke(nameof(ExecuteGrapple), grappleDelay);
        }
        else 
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;
            
            Invoke(nameof(StopGrapple), grappleDelay);
        }
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExecuteGrapple()
    {
        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + overShootYAxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = overShootYAxis;
        
        controller.JumpToPosition(grapplePoint, highestPointOnArc);
        Invoke(nameof(StopGrapple), 1f);
    }

    private void StopGrapple()
    {
        grappling = false;

        grappleTimer = grappleCooldown;

        lr.enabled = false;
    }
}
