using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    // Variables
    // To determine if the gem should be destroyed
    [SerializeField] private bool destroyObj;
    // Reference to the gem GameObject
    [SerializeField] GameObject gem;

    // Gem Sound Clip obj
    [SerializeField] private AudioClip gemSoundClip;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize destroyObj to true
        destroyObj = true;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Evaluates whether destroyObj is false and there is a GameObject tagged 'Gem'
        if (destroyObj == false && GameObject.FindGameObjectWithTag("Gem"))
        {
            //Refer to ScoreManager script.
            ScoreManager.instance.AddScore();
            
            // Play sound clip
            AudioManager.Instance.PlayVoiceOver(gemSoundClip);

            
            //Destroy obj.
            //2nd argument "0f" dictates the time of execution
            Destroy(gem, 0f);

            // Invoke MaxScore() function
            ScoreManager.instance.MaxScore();
        }

    }


    //When Player obj collides with coin obj the trigger is set. 
    //OnTrigger is utilized, so physics won't come to play when Player obj interacts with this game obj.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an object tagged as 'Player'
        if (other.gameObject.CompareTag("Player"))
        {
            // Set destroyObj to false, allowing the gem to be destroyed in FixedUpdate
            destroyObj = false;
        }
        
    }

}
