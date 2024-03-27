using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{

    private bool canMove = true;

    [Header("Set Gravity")]
    // gravity 
    [SerializeField] private float gravity = 20.0f;

    [Header("Set Character Values")]
    // character speeds
    [SerializeField] private float walkSpeed = 7.0f;
    [SerializeField] private float sprintSpeed = 13.0f;
    [SerializeField] private float jumpSpeed = 8.5f;

    [Header("Set Camera Controls")]
    // camera controls
    [SerializeField] private Camera playerCamera;
    [SerializeField] public float lookSpeed = 2.5f;
    [SerializeField] private float lookLimitX = 45.0f;


    [Header("Set Crouch Values")]
    [SerializeField] private float crouchSpeed = 3.0f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2.0f;

    private bool isCrouchKeyPressed = false;

    [Header("Set Animator")]
    [SerializeField] private Animator animator;
    public GunFire gunFire;

    // character controller
    CharacterController characterController;
    float rotationX = 0;
    Vector3 moveDirection = Vector3.zero;
    public bool activeGrapple;

    [Header("Flashlight")]
    public Light flashlight;
    public AudioSource flashlightSFX;


    [Header("Move Noises")]
    public AudioSource walkSound;
    public AudioSource sprintSound;


    void Start()
    {
        // Locks mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();

    }


    void Update()
    {

        if (PauseManager.IsGamePaused)
        {
            return;
        }

        if (activeGrapple) return;
        
        Vector3 moveForward = transform.TransformDirection(Vector3.forward);
        Vector3 moveRight = transform.TransformDirection(Vector3.right);


        // isSprinting to make player run

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        float speed = isCrouchKeyPressed ? crouchSpeed : (isSprinting ? sprintSpeed : walkSpeed);
        float cursorSpeedX = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float cursorSpeedY = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (moveForward * cursorSpeedX) + (moveRight * cursorSpeedY);

        bool isMoving = cursorSpeedX != 0 || cursorSpeedY != 0;
        bool isShooting = gunFire.IsShooting();
        
        // Play footstep sounds
        if (isMoving)
        {
            if (isSprinting)
            {
                if (!sprintSound.isPlaying)
                {
                    walkSound.Stop();
                    sprintSound.Play();
                }
            }
            else
            {
                if (!walkSound.isPlaying)
                {
                    sprintSound.Stop();
                    walkSound.Play();
                }
            }
        }
        else
        {
            walkSound.Stop();
            sprintSound.Stop();
        }

        if (!isShooting)
        {
            animator.SetBool("Moving", isMoving);
            animator.SetBool("Running", isSprinting && isMoving);
            animator.SetBool("notMoving", !isMoving);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            flashlight.enabled = !flashlight.enabled;
            flashlightSFX.Play();
        }

        // jump 

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (Input.GetKeyDown(KeyCode.C) && canMove)
        {
            isCrouchKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.C) && canMove)
        {
            isCrouchKeyPressed = false;
        }

        if (isCrouchKeyPressed)
        {
            // Check for obstacles above before crouching
            if (!CheckHeadObstacle())
            {
                characterController.height = crouchHeight;
            }
            else
            {
                isCrouchKeyPressed = true; // Keep crouching if obstacle above
            }
        }
        else
        {
            characterController.height = standingHeight;
        }

        // gravity 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Moves the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Camera
        if (canMove)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookLimitX, lookLimitX);
        }
    }

    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;
        moveDirection = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
    }


    public bool IsMoving()
    {
        return characterController.velocity.magnitude > 0;
    }

    void ToggleCrouch()
    {
        isCrouchKeyPressed = !isCrouchKeyPressed;

        if (isCrouchKeyPressed)
        {

            if (!CheckHeadObstacle())
            {
                characterController.height = crouchHeight;
            }
            else
            {
                isCrouchKeyPressed = true; // Keep crouching if obstacle above
            }
        }
        else
        {
            characterController.height = standingHeight;
        }
    }
        bool CheckHeadObstacle()
        {
            float radius = characterController.radius;
            float height = isCrouchKeyPressed ? crouchHeight : standingHeight;

            // Cast a sphere to check for obstacles above
            bool hasObstacle = Physics.SphereCast(
                transform.position + Vector3.up * (height - radius), // Start position
                radius, // Sphere radius
                Vector3.up, // Direction
                out RaycastHit hitInfo,
                height - radius, // Max distance
                ~LayerMask.GetMask("Player") // Ignore the player's own collider
            );

            return hasObstacle;
        }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));
        
        return velocityXZ + velocityY;
    }

    }
