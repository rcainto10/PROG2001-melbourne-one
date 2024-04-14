using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorXavier : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Added semicolon
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetKey("w");

        if (forward)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false); // Reset the boolean when not moving
        }
    }
}
