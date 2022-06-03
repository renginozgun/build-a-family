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

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void Play(){
        audioData.Play();
    }
}
