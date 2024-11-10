using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroyMusic : MonoBehaviour
{
    public string tagName;
    public AudioSource audioSource;
    public bool trueGamer;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
        AudioClip clip = audioSource.clip;

        foreach (var obj in objs)
        {
            DontDestroyMusic incScript = obj.GetComponent<DontDestroyMusic>();
            if (incScript.trueGamer)
            {
                AudioSource incomingSource = obj.GetComponent<AudioSource>();
                if (incomingSource.clip = clip)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(obj.gameObject);
                }
            }
            
        }

        DontDestroyOnLoad(this.gameObject);
        trueGamer = true;
    }
    private void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        if(audioSource.isPlaying == false) 
        {
            audioSource.Play();
        }
    }
}