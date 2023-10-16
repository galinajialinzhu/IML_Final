using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuo_Chang_Tiao : MonoBehaviour
{
    public float rollingSpeed = 5f;
    public float scalingSpeed = 0.05f;
    public Rigidbody doughRB;
    public GameObject hand;
    public string handName;

    public bool isRolling = false;


    // Start is called before the first frame update
    void Start()
    {
        doughRB.useGravity = false;
        doughRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hand != null)
        {
            if (isRolling)
            {
                // Vector3 directionToHand = hand.transform.position - transform.position;
                // directionToHand.y = 0;

                // float angle = Vector3.SignedAngle(transform.forward, directionToHand, Vector3.up);

                // doughRB.AddTorque(Vector3.up * angle *rollingSpeed);

                
                //rolling the dough smaller
                Vector3 currentScale = transform.localScale;
                Vector3 newScale = new Vector3(currentScale.x - scalingSpeed, currentScale.y + scalingSpeed * 3, currentScale.z - scalingSpeed);
                transform.localScale= newScale;

                if (newScale.x <= 0.05f)
                {
                    isRolling = false;
                }

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == handName || other.gameObject.name == "l_handMeshNode")
        {
            isRolling = true;
        }
    }
}
