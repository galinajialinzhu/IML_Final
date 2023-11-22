using UnityEngine;

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

    private void Start()
    {
        // Initial setup
        //animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
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
                audioSource.clip = audioClip3;
                audioSource.Play(); // Play the audio clip for state 3
                break;
            default:
                break;
        }
    }
}
