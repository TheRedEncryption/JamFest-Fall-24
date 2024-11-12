using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class VictoryScreen : MonoBehaviour
{
    public string newScene;
    public float fadeDuration;
    public float fadeDuration2;

    public Image HoorayText;
    public Image VictoryImage;
    public Image screenTransition;
    public Image TutorialText;
    public GameObject ThankYouText;
    public GameObject MenuButton;
    public AudioSource winMusic;
    bool startedWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!startedWin)
        {
            startedWin = true;
            StartCoroutine(FadeTutorialOut());
            StartCoroutine(FadeHoorayIn());
        }
        
    }

    public void ReturnToMenu()
    {
        StartCoroutine(FadeToBlack(newScene));
    }

    IEnumerator FadeTutorialOut()
    {
        HoorayText.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Debug.Log(elapsedTime);
        Color startColor = TutorialText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Set alpha to 1 for black
        while (elapsedTime < fadeDuration2)
        {
            TutorialText.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration2);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        TutorialText.color = targetColor;
        TutorialText.gameObject.SetActive(false);
        //StartCoroutine(FadeChibiIn());
    }

        IEnumerator FadeHoorayIn()
    {
        HoorayText.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Debug.Log(elapsedTime);
        Color startColor = HoorayText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Set alpha to 1 for black
        while (elapsedTime < fadeDuration)
        {
            HoorayText.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        HoorayText.color = targetColor;
        StartCoroutine(FadeChibiIn());
        winMusic.Play();
        // screenTransition.gameObject.SetActive(false);// Ensure final color is set correctly
    }

    IEnumerator FadeChibiIn()
    {
        VictoryImage.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Debug.Log(elapsedTime);
        Color startColor = VictoryImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Set alpha to 1 for black
        while (elapsedTime < fadeDuration)
        {
            VictoryImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        VictoryImage.color = targetColor;
        // screenTransition.gameObject.SetActive(false);// Ensure final color is set correctly
        StartCoroutine(ThankYouAndButton());
    }

    IEnumerator ThankYouAndButton()
    {
        float elapsedTime = 0f;
        while(elapsedTime < fadeDuration2)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ThankYouText.SetActive(true);
        StartCoroutine(JustButton());
        
    }
    IEnumerator JustButton()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration2)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        MenuButton.SetActive(true);
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

