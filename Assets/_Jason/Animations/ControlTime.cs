using UnityEngine;
using System.Collections;

public class ControlPu : MonoBehaviour
{
    public Animator animator;

    [Range(0.0f, 1.0f)]
    public float Ju;
    [Range(0.0f, 1.0f)]
    public float Pu;

    public Transform LTargetObject;
    public Transform RTargetObject;
    public Transform TopTrigger;
    public Transform BottomTrigger;
    
    public Transform FrontTrigger;
    public Transform BackTrigger;


    public float height;
    public float heightPercent;

    public float length;
    public float lengthPercent;

    private float dh;
    private float dl;

    private void Start()
    {
        float Ju = 0;
        float Pu = 0;

        height = 0;
        length = 0;

        heightPercent = 0;
        lengthPercent = 0;

        dh = TopTrigger.position.y - BottomTrigger.position.y;
        dl = FrontTrigger.position.z - BackTrigger.position.z;
    }

    private void Update()
    {
        height = RTargetObject.position.y - BottomTrigger.position.y;
        heightPercent = (dh - (TopTrigger.position.y - RTargetObject.position.y)) / dh;

        if (heightPercent <= 1 && heightPercent >= 0 ){
            
            Ju = heightPercent;
            
            animator.SetFloat("Ju", Ju);
        }else if (heightPercent > 1){
            Ju = 1;
        }else{
            Ju = 0;
        }

        length = RTargetObject.position.z - BackTrigger.position.z;
        lengthPercent = (dl - (FrontTrigger.position.z - RTargetObject.position.z)) / dl;

        if ((lengthPercent <= 1 && lengthPercent >= 0) || (heightPercent <= 1 && heightPercent >= 0)){
            
            Pu = (float)(heightPercent*.4 + lengthPercent*.6);
            
            animator.SetFloat("Pu", Pu);
        }else if (lengthPercent > 1){
            Pu = 1;
        }else{
            Pu = 0;
        }

    }
}