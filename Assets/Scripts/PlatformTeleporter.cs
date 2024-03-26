using UnityEngine;

public class PlatformTeleporter : MonoBehaviour
{
    public Transform teleportDestination; 
    public KeyCode teleportKey = KeyCode.E;
    public GameObject actionText;
    public AudioSource teleportSound;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(teleportKey))
        {
            TeleportPlayer();
            teleportSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionText.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionText.SetActive(false);
            playerInRange = false;
        }
    }

    private void TeleportPlayer()
    {
        if (teleportDestination != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            if (player != null)
            {
                CharacterController characterController = player.GetComponent<CharacterController>();
                if (characterController != null)
                {
                    characterController.enabled = false;
                    player.transform.position = teleportDestination.position;
                    player.transform.rotation = teleportDestination.rotation;
                    characterController.enabled = true;
                    actionText.SetActive(false);
                    playerInRange = false;
                }
                else
                {
                    Debug.LogError("CharacterController component not found on player!");
                }
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
        else
        {
            Debug.LogError("Teleport destination is not set!");
        }
    }
}
