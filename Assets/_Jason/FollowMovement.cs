using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{

    public Transform LTargetObject;
    public Transform RTargetObject;
    public Transform LFollower;
    public Transform RFollower;
    private Vector3 Loffset;
    private Vector3 Roffset;
    // Start is called before the first frame update
    void Start()
    {
        Loffset = LTargetObject.position - LFollower.position;
        Roffset = RTargetObject.position - RFollower.position;
    }

    // Update is called once per frame
    void Update()
    {
        LFollower.position = LTargetObject.position - Loffset;
        LFollower.rotation = LTargetObject.rotation;
        RFollower.position = RTargetObject.position - Roffset;
        RFollower.rotation = RTargetObject.rotation;
    }
}
