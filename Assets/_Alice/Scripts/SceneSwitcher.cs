using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load.
    public string triggeringTag = "Player"; // Tag of the object that triggers the scene switch

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggeringTag)) // Check if the colliding object has the specified tag
        {
            SceneManager.LoadScene(sceneToLoad); // Load the scene
        }
    }
}