using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Timeline;
public class MainMenuHandler : MonoBehaviour
{
    public string initialScene;
    public float fadeDuration;
    public Image screenTransition;
    public AudioMixerGroup music;
    public Toggle musicToggle;

    void Start()
    {
        
    }
    public void startGame()
    {
        PersistentData.Reset();
        StartCoroutine(FadeToBlack(initialScene));
    }

    public void toggleMusicPlease(bool setting)
    {
        if(setting)
        {
            music.audioMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            music.audioMixer.SetFloat("MusicVolume", 0f);
        }
    }

    IEnumerator FadeToBlack(string sceneName)
    {
        screenTransition.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Debug.Log(elapsedTime);
        Color startColor = screenTransition.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Set alpha to 1 for black
        while (elapsedTime < fadeDuration)
        {
            screenTransition.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        screenTransition.color = targetColor;
        // screenTransition.gameObject.SetActive(false);// Ensure final color is set correctly
        SceneManager.LoadScene(sceneName);
    }
}
