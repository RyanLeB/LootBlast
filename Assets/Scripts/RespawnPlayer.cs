using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{

    private Vector3 initialPosition;
    private CharacterController characterController;

    

    
    void Start()
    {
        
        initialPosition = transform.position;
        characterController = GetComponent<CharacterController>();
    }

        

    
    void Update()
    {
        
        if (transform.position.y < -10f) 
        {
            
            Respawn();
        }
    }

    
    void Respawn()
    {
        
        characterController.enabled = false; 
        transform.position = initialPosition;
        characterController.enabled = true; 

        
    }
}
