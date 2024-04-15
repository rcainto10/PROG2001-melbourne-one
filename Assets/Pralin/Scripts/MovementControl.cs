using System.Collections;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    // Variables
    private CharacterController characterController;
    private Vector2 movementInput;
    private Vector3 movementDirection; // Declare movementDirection here

    [SerializeField] private float moveSpeed;

    // Jump
    private Vector3 velocity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    private bool isGrounded;

    [SerializeField] private Transform cameraTransform;

    // Animation
    //private Animator animator;

    // Sound
    // Footsteps
    public GameObject footstepSound;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        footstepSound.SetActive(false);
        // Releases the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if player is grounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, LayerMask.GetMask("Ground"));

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized;

        // Rotate movementDirection based on camera rotation
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        if (movementDirection.magnitude >= 0.1f)
        {
            characterController.Move(movementDirection * moveSpeed * Time.deltaTime);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -4f * gravity);
        }

        // Running Animation/Sound
        if (movementDirection != Vector3.zero)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localEulerAngles = Vector3.zero;
            }
            //animator.SetBool("isMoving", true);
            // Play footstep sound
            PlayFootstepSound();
        }
        else
        {
            // Disable moving animation
            //animator.SetBool("isMoving", false);
            // Stop footstep sound
            StopFootstepSound();
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    // Footstep functions
    // Enable footstep sound function
    void PlayFootstepSound()
    {
        footstepSound.SetActive(true);
    }

    // Disable footstep sound
    void StopFootstepSound()
    {
        footstepSound.SetActive(false);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked; // Corrected typo here
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Corrected typo here
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //Destroy(other.gameObject);
            ScoreImplementer.scoreCount += 1;
        }
    }
}
