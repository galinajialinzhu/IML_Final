using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithController : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform centerEyeAnchor; // Assign the CenterEyeAnchor in the Inspector
    public float minTiltAngle = 20f;
    public float maxTiltAngle = 90f; // Maximum tilt angle
    public float minSpeed = 1f; // Minimum speed at min tilt
    public float maxSpeed = 5f; // Maximum speed at max tilt

    private float currentSpeed = 0f;

    void Update()
    {
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        float tiltAngle = controllerRotation.eulerAngles.x;

        // Adjust for the fact that tilting forward can give angles > 180
        if (tiltAngle > 180) tiltAngle -= 360;

        // Map the tilt angle to a speed
        if (tiltAngle >= minTiltAngle && tiltAngle <= maxTiltAngle)
        {
            // Calculate speed based on tilt angle
            float normalizedTilt = (tiltAngle - minTiltAngle) / (maxTiltAngle - minTiltAngle);
            currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, normalizedTilt);

            // Calculate the forward direction based on the Y rotation of the CenterEyeAnchor
            Vector3 forwardDirection = Quaternion.Euler(0, centerEyeAnchor.eulerAngles.y, 0) * Vector3.forward;
            transform.Translate(forwardDirection * currentSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            currentSpeed = 0f;
        }
    }
}