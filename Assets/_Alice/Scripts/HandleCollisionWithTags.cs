using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.Events;

public class HandleCollisionWithTags : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("Whether to check for tags or not.")]
    public bool useTags = true;

    [Header("Tags")]
    [Tooltip("List of tags that should trigger the events.")]
    public List<string> targetTags;

    [Header("Collision Events")]
    [Tooltip("Triggered when a collision starts with a target tag.")]
    public UnityEvent onCollisionEnter;

    [Tooltip("Triggered when a collision ends with a target tag.")]
    public UnityEvent onCollisionExit;

    private void OnCollisionEnter(Collision collision)
    {
        if (!useTags || (targetTags.Contains(collision.gameObject.tag)))
        {
            onCollisionEnter?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!useTags || (targetTags.Contains(collision.gameObject.tag)))
        {
            onCollisionExit?.Invoke();
        }
    }
}






