using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    public Transform door;
    public float openDistance = 2f;
    public float speed = 2f;
    public Vector3 movementDirection = Vector3.right; 
    private Vector3 initialPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    public AudioSource doorNoise;
    public AudioSource doorClose;

    private void Start()
    {
        initialPosition = door.position;
        openPosition = initialPosition + movementDirection * openDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
            doorNoise.Play();
            isClosing = false; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClosing = true;
            doorClose.Play();
            isOpening = false; 
        }
    }

    private void Update()
    {
        if (isOpening)
        {
            OpenDoor();
        }
        else if (isClosing)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        door.position = Vector3.MoveTowards(door.position, openPosition, speed * Time.deltaTime);
        if (Vector3.Distance(door.position, openPosition) < 0.01f)
        {
            isOpening = false;
        }
    }

    private void CloseDoor()
    {
        door.position = Vector3.MoveTowards(door.position, initialPosition, speed * Time.deltaTime);
        if (Vector3.Distance(door.position, initialPosition) < 0.01f)
        {
            isClosing = false;
        }
    }
}