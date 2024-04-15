using System.Collections;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    // Variables
    private CharacterController characterController;   // Reference to the CharacterController component
    private Vector2 movementInput;                     // Player's movement input (horizontal and vertical)
    private Vector3 movementDirection;                 // Direction of movement

    [SerializeField] private float moveSpeed;         // Movement speed

    // Jump
    private Vector3 velocity;                          // Player's velocity
    [SerializeField] private float jumpHeight;        // Jump height
    [SerializeField] private float gravity;           // Gravity force
    private bool isGrounded;                           // Flag to check if the player is grounded

    [SerializeField] private Transform cameraTransform; // Reference to the camera's transform
    [SerializeField] private AudioClip coinCollectSound; // Sound clip for coin collection
    [SerializeField] private AudioClip footstepSound; // Footstep sound clip

    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();

        // Add an AudioSource component to this GameObject and configure it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Set loop to true for continuous playback
        audioSource.clip = footstepSound; // Assign footstep sound clip

        // Set cursor lock state
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, LayerMask.GetMask("Ground"));

        // If the player is grounded and moving downward, reset the vertical velocity to avoid falling through the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        // Get player's movement input
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Calculate movement direction based on input and camera rotation
        movementDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        // Move the player
        if (movementDirection.magnitude >= 0.1f)
        {
            characterController.Move(movementDirection * moveSpeed * Time.deltaTime);
            
            // Play footstep sound if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop footstep sound if player is not moving
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -4f * gravity);
        }

        // Apply gravity to the player
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    // Handle cursor lock state when application focus changes
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

    // Handle trigger collisions
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a coin
        if (other.gameObject.tag == "Coin")
        {
            // Play coin collection sound
            PlaySound(coinCollectSound);

            // Increment score count
            ScoreImplementer.scoreCount += 1;

            // Destroy the coin object
            Destroy(other.gameObject);
        }
    }

    // Method to play a sound clip
    void PlaySound(AudioClip clip)
    {
        // Check if the sound clip is assigned
        if (clip != null)
        {
            // Play the sound clip
            audioSource.PlayOneShot(clip);
        }
    }
}
