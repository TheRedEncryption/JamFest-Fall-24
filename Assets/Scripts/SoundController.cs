using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void playAudio()
    {
        audioSource.Play();
    }

}
