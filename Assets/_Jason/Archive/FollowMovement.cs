using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{

    public Transform LTargetObject;
    public Transform RTargetObject;
    public Transform trigger1;
    public Transform trigger2;

    public float tiger_time;

    public float height;
    public float heightPercent;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        height = 0;
        heightPercent = 0;
        distance = trigger1.position.y - trigger2.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        height = RTargetObject.position.y - trigger2.position.y;
        heightPercent = (distance - (trigger1.position.y - RTargetObject.position.y)) / distance;

        //tiger_time = Tiger.ControlTime.time;
        if (heightPercent <= 1 && heightPercent >= 0 ){
            
            //Tiger.ControlTime.time = heightPercent;
        }
    }
}
