using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using System.Collections;
using System.Collections.Generic;
public class SceneTransition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string newScene;
    public float fadeDuration;
    public Image screenTransition;
    public Vector3 locationOnLoad;

    void Start()
    {
        //screenTransition = GameObject.FindWithTag("ScreenTransition").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ouch!");
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine(FadeToBlack(newScene));
        }
        else if(other.transform.parent !=null)
        {
            if(other.transform.parent.gameObject.tag == "Player")
            {
                StartCoroutine(FadeToBlack(newScene));
            }
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
