using UnityEngine;
using System.Collections;

public class ControlTime : MonoBehaviour
{
    public Animator animator;

    [Range(0.0f, 1.0f)]
    public float time;

    public Transform LTargetObject;
    public Transform RTargetObject;
    public Transform trigger1;
    public Transform trigger2;

    public float height;
    public float heightPercent;

    private float distance;

    private void Start()
    {
        float time = 0;

        height = 0;
        heightPercent = 0;
        distance = trigger1.position.y - trigger2.position.y;
    }

    private void Update()
    {
        height = RTargetObject.position.y - trigger2.position.y;
        heightPercent = (distance - (trigger1.position.y - RTargetObject.position.y)) / distance;

        if (heightPercent <= 1 && heightPercent >= 0 ){
            
            time = heightPercent;
            
            animator.SetFloat("Time", time);
        }else if (heightPercent > 1){
            time = 1;
        }else{
            time = 0;
        }

    }
}