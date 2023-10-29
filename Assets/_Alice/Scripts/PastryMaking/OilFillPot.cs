using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OilFillPot : MonoBehaviour
{
    [Header("Settings")]
    public GameObject oilInPot;   // The GameObject representing the oil level inside the pot.
    public GameObject tracker;    // The tracker object that detects the collision.
    public GameObject referenceObject; // The object whose position and scale will be the target.
    public float fillDuration;        // Duration over which the filling takes place.
    public float boilingTime;     // Time for the oil to boil after filling.

    [Header("Boiling Completion Event")]
    public UnityEvent onBoilingCompleted;  // Events to run after boiling is complete.

    private bool isFilling = false; // Flag to check if oil is filling.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == tracker && !isFilling)  // Check for the specific tracker object
        {
            StartCoroutine(FillPot());
        }
    }

    IEnumerator FillPot()
    {
        isFilling = true;
        float elapsedTime = 0;

        Vector3 initialPosition = oilInPot.transform.position;
        Vector3 targetPosition = referenceObject.transform.position;
        Vector3 initialScale = oilInPot.transform.localScale;
        Vector3 targetScale = referenceObject.transform.localScale;

        while (elapsedTime < fillDuration)
        {
            float progress = elapsedTime / fillDuration;

            // Update position and scale based on progress
            oilInPot.transform.position = Vector3.Lerp(initialPosition, targetPosition, progress);
            oilInPot.transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final values are set
        oilInPot.transform.position = targetPosition;
        oilInPot.transform.localScale = targetScale;

        isFilling = false;

        // Start boiling phase
        yield return new WaitForSeconds(boilingTime);

        // Invoke events after boiling
        onBoilingCompleted.Invoke();
    }
}
