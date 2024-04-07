using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Youtube Guide Reference: https://www.youtube.com/watch?v=iHzAwGg--LM

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector2 movement;
    public float moveSpeed;

    //Jump
    Vector3 velocity;
    public float jumpHeight;
    public float gravity;
    bool isGrounded;

    //Animation
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (direction != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else {
            anim.SetBool("isMoving", false);
        }

        velocity.y += (gravity * 10) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

  
}
