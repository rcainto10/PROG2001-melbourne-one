using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Reference: https://adamwreed93.medium.com/how-to-create-and-utilize-an-audio-manager-in-unity-627123d2483

    private static AudioManager instance;
    public AudioSource voiceOver;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Audio Manager is null");
            }
            return instance;
        }
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        voiceOver.clip = clip;
        voiceOver.Play();
    }

    private void Awake()
    {
        instance = this;
    }
}
