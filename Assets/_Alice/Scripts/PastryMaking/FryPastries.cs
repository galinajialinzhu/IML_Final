using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FryPastries : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("Whether to check for tags or not.")]
    public bool useTags = true;

    [Header("Tags")]
    [Tooltip("List of tags that should trigger the events.")]
    public List<string> targetTags;

    [Header("Time Settings")]
    public float greatTime;  // The duration for the GreatTime event.
    public float longTime;   // The duration for the LongTime event.

    private float timeInsideTrigger = 0f; // Time the object has stayed in the trigger.

    [Header("Trigger Events")]
    [Tooltip("Triggered when a starts with a target tag.")]
    public UnityEvent onTriggerEnter;

    [Tooltip("Triggered when trigger stay with a target tag for GreatTime.")]
    public UnityEvent onGreatTimeStay;

    [Tooltip("Triggered when trigger stay with a target tag for LongTime.")]
    public UnityEvent onLongTimeStay;

    [Tooltip("Triggered when a trigger ends with a target tag.")]
    public UnityEvent onTriggerExit;

    private bool greatTimeEventTriggered = false;
    private bool longTimeEventTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (IsTagValid(other.gameObject.tag))
        {
            timeInsideTrigger = 0f;
            greatTimeEventTriggered = false;
            longTimeEventTriggered = false;
            onTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsTagValid(other.gameObject.tag))
        {
            timeInsideTrigger += Time.deltaTime;

            if (!greatTimeEventTriggered && timeInsideTrigger >= greatTime)
            {
                onGreatTimeStay?.Invoke();
                greatTimeEventTriggered = true;
            }

            if (!longTimeEventTriggered && timeInsideTrigger >= longTime)
            {
                onLongTimeStay?.Invoke();
                longTimeEventTriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsTagValid(other.gameObject.tag))
        {
            timeInsideTrigger = 0f; // Reset the timer
            onTriggerExit?.Invoke();
        }
    }

    private bool IsTagValid(string tag)
    {
        return !useTags || targetTags.Contains(tag);
    }
}
