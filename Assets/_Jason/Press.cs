using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Press : MonoBehaviour
{
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            triggered = true;
            Vector3 currentScale = transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x - 0.01f, currentScale.y + 0.005f, currentScale.z + 0.005f);
            transform.localScale= newScale;
        }
    }

}
