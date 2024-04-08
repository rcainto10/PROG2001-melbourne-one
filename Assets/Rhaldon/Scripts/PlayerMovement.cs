using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Youtube Movement Guide Reference: https://www.youtube.com/watch?v=iHzAwGg--LM
// Rotate Guide: https://www.youtube.com/watch?v=LnQudtIKfnw

public class PlayerMovement : MonoBehaviour
{
    // Variables
    CharacterController controller;
    Vector2 movement;
    [SerializeField] float moveSpeed;

    //Jump
    Vector3 velocity;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity;
    [SerializeField] bool isGrounded;

    //Animation
    private Animator anim;

    // Sound
    // Footstep
    public GameObject footsteps;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        footsteps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if player is grounded
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -1;
        }

        movement = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Normalized is used to avoid player sprinting in a diagonal direction.
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f) {
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
        }

        // Running Animation/Sound
        if (direction != Vector3.zero)
        {
            // Rotate Player Character to the back if user clicks on S key.
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W)) {
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            anim.SetBool("isMoving", true);
            // Play footstep sfx
            footStep();
        }
        else {
            // Disable Moving animaion
            anim.SetBool("isMoving", false);
            // Disable Footsteps
            stopFootStep();
        }

        velocity.y += (gravity * 10) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Footstep functions
    // Enable Footstep sfx function
    void footStep() { 
        footsteps.SetActive(true);
    }

    // Disable Footstep sfx
    void stopFootStep() {
        footsteps.SetActive(false);
    }
  
}
