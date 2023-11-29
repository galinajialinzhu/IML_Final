using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class MoveWithController : MonoBehaviour 
{ 
    [Header("Movement Settings")] 
    public Transform centerEyeAnchor; // Assign the CenterEyeAnchor in the Inspector 
    public Transform hand1; 
    public Transform hand2; 
 
    void Update() 
    { 
        Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch); 
 
        float handDistance = Vector3.Distance(hand1.position, hand2.position); 
 
        // Map the tilt angle to a speed 
        if (handDistance > 0.8f) 
        { 
 
            // Calculate the forward direction based on the Y rotation of the CenterEyeAnchor 
            Vector3 forwardDirection = Quaternion.Euler(0, centerEyeAnchor.eulerAngles.y, 0) * Vector3.forward; 
            transform.Translate(forwardDirection * 1 * Time.deltaTime, Space.World); 
        } 
    } 
}