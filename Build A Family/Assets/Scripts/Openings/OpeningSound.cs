using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSound : MonoBehaviour
{
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        Invoke("Play", 2f);
    }


    void Play(){
        audioData.Play();
    }
}
