using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    [SerializeField] private bool destroyObj;
    [SerializeField] GameObject gem;

    // Gem Sound Clip obj
    [SerializeField] private AudioClip gemSoundClip;

    // Start is called before the first frame update
    private void Start()
    {
        destroyObj = true;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Evaluates whether bool is false and the Game object is tagged 'Coin'
        if (destroyObj == false && GameObject.FindGameObjectWithTag("Gem"))
        {
            //Refer to ScoreManager script.
            ScoreManager.instance.AddScore();
            
            AudioManager.Instance.PlayVoiceOver(gemSoundClip);

            
            //Destroy obj.
            //2nd argument "0f" dictates the time of execution
            Destroy(gem, 0f);

            ScoreManager.instance.MaxScore();
        }

    }


    //When Player obj collides with coin obj the trigger is set. 
    //OnTrigger is utilized, so physics won't come to play when Player obj interacts with this game obj.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            destroyObj = false;
            
        }
        
        
    }

}
