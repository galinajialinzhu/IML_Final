using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleTrigger : MonoBehaviour
{
    [Header("Trigger Events")]
    [Tooltip("Triggered when a trigger starts.")]
    public UnityEvent onTriggerEnter;

    [Tooltip("Triggered when a trigger ends.")]
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke();
    }
}
