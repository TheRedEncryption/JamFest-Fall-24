using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void playAudio()
    {
        audioSource.Play();
    }

}
