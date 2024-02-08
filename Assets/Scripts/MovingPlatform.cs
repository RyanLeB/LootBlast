using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints; // Define waypoints for platform movement
    public float speed = 2f; // Speed of the platform

    private int currentWaypointIndex = 0;
    private bool playerOnPlatform = false;
    private Transform playerTransform;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // If the platform is close enough to the current waypoint, move to the next waypoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (playerOnPlatform && playerTransform != null)
        {
            // Calculate the difference in position since the last frame
            Vector3 movementDelta = transform.position - previousPosition;

            // Update the player's position by the same amount to keep it relative to the platform
            playerTransform.position += movementDelta;
        }

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            playerTransform = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            playerTransform = null;
        }
    }
}

