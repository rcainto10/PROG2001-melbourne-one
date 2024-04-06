using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Youtube Guide Reference: https://www.youtube.com/watch?v=iHzAwGg--LM

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector2 movement;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       movement = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Normalized is used to avoid player sprinting in a diagonal direction.
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f) {
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }
    }

  
}
