using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStartSound : MonoBehaviour
{

    // Cached component references
    AudioSource myAudioSource;
    [SerializeField] AudioClip startAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        // Play audioclip
        AudioSource.PlayClipAtPoint(startAudio, Camera.main.transform.position);
    }
}
