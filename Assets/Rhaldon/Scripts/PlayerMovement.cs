using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// References:
// Movement Guide: https://www.youtube.com/watch?v=iHzAwGg--LM
// Rotation Guide: https://www.youtube.com/watch?v=LnQudtIKfnw

public class PlayerMovement : MonoBehaviour
{
    // Reference to the CharacterController used to enable physical player movement.
    CharacterController controller;

    // Stores the raw input values for player's horizontal and vertical movement.
    Vector2 movementInput;

    // Vector3 to hold and calculate the direction of player movement.
    private Vector3 movementDirection;

    // Movement speed of the player, adjustable in the Unity Inspector for easy tuning.
    [SerializeField] float moveSpeed;

    // Reference to the ScoreManager component for managing game scoring.
    ScoreManager scoreManager;

    // Vector3 used for calculating the effects of gravity and jump physics.
    Vector3 velocity;

    // Jump height, adjustable in the Unity Inspector to fine-tune jump dynamics.
    [SerializeField] float jumpHeight;

    // Gravity value, editable in Unity Inspector to adjust the gravitational pull on the player.
    [SerializeField] float gravity;

    // Boolean to check if the player is touching the ground.
    [SerializeField] bool isGrounded;

    // Animator component for handling player animations.
    private Animator anim;

    // GameObject that controls the footstep sounds.
    public GameObject footsteps;

    // Camera Transform to align movement direction with camera's orientation.
    [SerializeField] private Transform cameraTransform;

    // Start is called before the first frame update.
    void Start()
    {
        // Retrieve the Animator and CharacterController components from the GameObject.
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Footsteps audio is initially disabled to avoid playing sounds when not moving.
        footsteps.SetActive(false);

        // Releases the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame.
    void Update()
    {
        // Check if player is on the ground by checking collision with the ground layer.
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        // Reset the vertical velocity when the player is grounded to stop falling motion.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        // Capture player input and convert it into a movement direction vector.
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Normalize to prevent faster diagonal movement.
        movementDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized;

        // Adjust movement direction based on the camera's current rotation.
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        // Move the player using the CharacterController.
        if (movementDirection.magnitude >= 0.1f)
        {
            controller.Move(movementDirection * moveSpeed * Time.deltaTime);
        }

        // Process jumping input and physics.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 10 * -2f * gravity);
        }

        // Handle player rotation and animation states.
        if (movementDirection != Vector3.zero)
        {
            // Play running animation and activate footstep sounds.
            anim.SetBool("isMoving", true);
            FootStep();
        }
        else
        {
            // Stop running animation and footstep sounds when movement ceases.
            anim.SetBool("isMoving", false);
            StopFootStep();
        }

        // Apply gravity to the player's vertical velocity and move the player.
        velocity.y += gravity * 10 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Enable footstep sound effects.
    void FootStep()
    {
        footsteps.SetActive(true);
    }

    // Disable footstep sound effects.
    void StopFootStep()
    {
        footsteps.SetActive(false);
    }

    // Manage the cursor locking state based on application focus.
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
