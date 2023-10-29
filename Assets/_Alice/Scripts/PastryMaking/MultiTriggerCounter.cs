using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiTriggerCounter : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The object that will enter the triggers.")]
    public GameObject trackedObject;

    [Tooltip("List of trigger colliders that should be entered.")]
    public List<Collider> targetTriggers;

    [Tooltip("How many times should all triggers be entered by the tracked object?")]
    public int requiredTimes = 1;

    [Header("Events")]
    [Tooltip("List of events to execute when the tracked object enters all target triggers the required number of times.")]
    public UnityEvent onAllTriggersEntered;

    private HashSet<Collider> enteredTriggers = new HashSet<Collider>();
    private int timesCompleted = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == trackedObject && targetTriggers.Contains(other))
        {
            Debug.Log("Entered: " + other.name); // Add this debug line
            enteredTriggers.Add(other);
            CheckCompletion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == trackedObject && targetTriggers.Contains(other))
        {
            enteredTriggers.Remove(other);
        }
    }

    private void CheckCompletion()
    {
        if (enteredTriggers.Count == targetTriggers.Count)
        {
            Debug.Log("All triggers entered!"); // Add this debug line
            timesCompleted++;
            enteredTriggers.Clear();

            if (timesCompleted >= requiredTimes)
            {
                onAllTriggersEntered.Invoke();
                timesCompleted = 0; // Reset the counter if you want to reuse the mechanic, otherwise remove this line.
            }
        }
    }
}
