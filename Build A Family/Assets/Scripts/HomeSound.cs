using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSound : MonoBehaviour
{
    private AudioSource _audioSource;

    public static HomeSound Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
