using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// Youtube Movement Guide Reference: https://www.youtube.com/watch?v=iHzAwGg--LM
// Rotate Guide: https://www.youtube.com/watch?v=LnQudtIKfnw

public class PlayerMovement : MonoBehaviour
{

    // Variables
    // Reference to the CharacterController component for controlling player movement.
    CharacterController controller;
    // Stores the input values for player movement.
    Vector2 movement;
    // Movement speed of the player, editable in the Unity Inspector.
    [SerializeField] float moveSpeed;

    // Reference to the ScoreManager component
    ScoreManager scoreManager;

    // Used for applying gravity and jump calculations.
    Vector3 velocity;
    // Jump height, editable in the Unity Inspector.
    [SerializeField] float jumpHeight;
    // Gravity value to apply to the velocity, editable in the Unity Inspector.
    [SerializeField] float gravity;
    // Boolean flag to check if the player is on the ground.
    [SerializeField] bool isGrounded;

    // Animator component reference for handling animations.
    private Animator anim;

    // GameObject reference for enabling/disabling footstep sounds.
    public GameObject footsteps;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize animator and controller by getting the components from the game object.
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Initially disable footsteps to prevent them from playing.
        footsteps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if player is grounded
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        // Reset vertical velocity when grounded.
        if (isGrounded && velocity.y < 0) {
            velocity.y = -1;
        }

        // Read player input and convert it into movement direction.
        movement = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Normalized is used to avoid player sprinting in a diagonal direction.
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        // Move the player using the CharacterController.
        if (direction.magnitude >= 0.1f) {
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
        }

        // Rotate the player based on movement direction and play running animations/sounds.
        if (direction != Vector3.zero)
        {
            // Set rotation of the player based on directional input.
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.A)) {
                transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            }

            // Activate the moving animation.
            anim.SetBool("isMoving", true);

            // Activate footstep sound effects.
            FootStep();
        }
        else {
            // Disable Moving animaion
            anim.SetBool("isMoving", false);
            // Disable Footsteps sound effects
            StopFootStep();
        }

        // Apply gravity to the velocity and move the player.
        velocity.y += (gravity * 10) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    /**
     * FootStep Function
     * Enable footsteps sound effects
     */
    void FootStep() { 
        footsteps.SetActive(true);
    }

    /**
     * StopFootStep Function
     * Disable Footstep sound effects
     */
    void StopFootStep() {
        footsteps.SetActive(false);
    }

   
    
}
