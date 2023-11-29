using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class Huatuo : MonoBehaviour
{
    public Animator animator;
    public int state = 1; // 1: stand, 2: updown, 3: thanks
    public GameObject Hand;

    private float stateChangeTime = 0f;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioSource audioSource;

    private bool hasSceneChanged = false;

    private void Start()
    {
        // Initial setup
        SetHuatuoState(1);
    }

    private void Update()
    {
        if (state == 1)
        {
            Debug.Log(Time.time);
            if (Time.time > stateChangeTime + 50f)
            {
                SetHuatuoState(2);
            }
        }

        if (state == 2)
        {
            // Check if the audio clip is not playing
            if (!audioSource.isPlaying)
            {
                // Set the audio clip and play it
                audioSource.clip = audioClip2;
                audioSource.Play();
            }

            if (Hand.transform.position.y > 1.5f)
            {
                SetHuatuoState(3);
            }
        }

        if (state == 3 && !audioSource.isPlaying && !hasSceneChanged)
        {
            // Play the audio clip for state 3
            audioSource.clip = audioClip3;
            audioSource.Play();
            hasSceneChanged = true; // Mark that the scene has changed

            // Perform a fade-out transition before changing the scene
            StartCoroutine(FadeOutAndChangeScene("00 Home", audioClip3.length));
        }
    }

    private void SetHuatuoState(int newState)
    {
        state = newState;
        animator.SetInteger("HuatuoState", newState);
        stateChangeTime = Time.time;

        // Set the appropriate audio clip based on the state
        switch (newState)
        {
            case 1:
                audioSource.clip = audioClip1;
                break;
            case 2:
                // Audio clip 2 will be handled in the Update method
                break;
            case 3:
                // Audio clip 3 will be handled in the Update method
                break;
            default:
                break;
        }
    }

    private IEnumerator FadeOutAndChangeScene(string sceneName, float delay)
    {
        Image fadeImage = GetComponentInChildren<Image>(); // Assuming the Image component is a child of the Canvas
        Color startColor = fadeImage.color;
        startColor.a = 0f; // Set initial alpha to 0

        float elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / delay);
            fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Change the scene after the fade-out
        SceneManager.LoadScene(sceneName);
    }
}
