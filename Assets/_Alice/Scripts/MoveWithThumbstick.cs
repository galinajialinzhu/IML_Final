using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithThumbstick : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform centerEyeAnchor; // Assign the CenterEyeAnchor in the Inspector
    public float maxSpeed = 5f; // Maximum speed at full thumbstick tilt

    void Update()
    {
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        // The forward movement speed is proportional to how much the thumbstick is tilted forward
        float forwardSpeed = thumbstickInput.y * maxSpeed;

        if (forwardSpeed > 0f)
        {
            // Calculate the forward direction based on the Y rotation of the CenterEyeAnchor
            Vector3 forwardDirection = Quaternion.Euler(0, centerEyeAnchor.eulerAngles.y, 0) * Vector3.forward;
            transform.Translate(forwardDirection * forwardSpeed * Time.deltaTime, Space.World);
        }
    }
}