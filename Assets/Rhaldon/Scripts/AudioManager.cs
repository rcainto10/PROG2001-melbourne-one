using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Reference Guide: https://adamwreed93.medium.com/how-to-create-and-utilize-an-audio-manager-in-unity-627123d2483

    // AudioManager instance
    private static AudioManager instance;
    // AudioSource object
    public AudioSource voiceOver;

    // Makes this accessible without requiring to instantiate.
    public static AudioManager Instance
    {
        // Gets the instance of an assigned audio clip
        get
        {
            if (instance == null)
            {
                Debug.LogError("Audio Manager is null");
            }
            return instance;
        }
    }

    /**
     * PlayVoiceOver Function
     * Plays a specific audio clip using the voiceOver AudioSource.
     * This function is designed to ensure the audio clip starts playing immediately
     * when this method is called, overriding any currently playing clips if necessary.
     *
     * @param clip The audio clip to be played.
     */
    public void PlayVoiceOver(AudioClip clip)
    {

        // Assign the provided clip to the AudioSource
        voiceOver.clip = clip;
        // Play the audio clip from the beginning
        voiceOver.Play();
    }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Assign this instance to the instance variable
        instance = this;
    }
}
