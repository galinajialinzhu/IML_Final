using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleTriggerWithTags : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("Whether to check for tags or not.")]
    public bool useTags = true;

    [Header("Tags")]
    [Tooltip("List of tags that should trigger the events.")]
    public List<string> targetTags;

    [Header("Trigger Events")]
    [Tooltip("Triggered when a starts with a target tag.")]
    public UnityEvent onTriggerEnter;

    [Tooltip("Triggered when trigger stay with a target tag.")]
    public UnityEvent onTriggerStay;

    [Tooltip("Triggered when a trigger ends with a target tag.")]
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!useTags || (targetTags.Contains(other.gameObject.tag)))
        {
            onTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!useTags || (targetTags.Contains(other.gameObject.tag)))
        {
            onTriggerStay?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!useTags || (targetTags.Contains(other.gameObject.tag)))
        {
            onTriggerExit?.Invoke();
        }
    }
}
