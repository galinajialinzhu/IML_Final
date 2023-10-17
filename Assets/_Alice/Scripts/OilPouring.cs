using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPouring : MonoBehaviour
{
    public Transform oilContainer;
    public Transform spoutTracker;  // Reference to the SpoutTracker GameObject
    public GameObject oilEmitter;

    public float rotationThresholdMin = 100f; // Minimum threshold for the rotation
    public float rotationThresholdMax = 180f; // Maximum threshold for the rotation

    void Update()
    {
        float currentZRotation = oilContainer.rotation.eulerAngles.z;

        // Check if the z rotation of the oil container is within the range of 100 to 180 degrees
        if (currentZRotation >= rotationThresholdMin && currentZRotation <= rotationThresholdMax)
        {
            // Place the OilEmitter at the position of the SpoutTracker but ensure it remains vertical
            oilEmitter.transform.position = spoutTracker.position;
            oilEmitter.SetActive(true); // Start pouring oil.
        }
        else
        {
            oilEmitter.SetActive(false); // Stop pouring oil.
        }
    }
}



