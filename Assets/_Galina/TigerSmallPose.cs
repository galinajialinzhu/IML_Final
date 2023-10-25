using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerSmallPose : MonoBehaviour
{

    public GameObject DetectBall;
    public int numberOfObjects;
    public float x,y,z;
    public List<Vector3> locate = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        //locate.Add(new Vector3(0, 0, 0));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            TigerPose();
        }
        
    }

    void TigerPose()
    {
         for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newObject = Instantiate(DetectBall);

            locate.Add(new Vector3(0, y, z));
            y+=0.1f;
            z=(1.0f / 2.0f)*y*y-y+1;
            newObject.transform.position = locate[i];

            
        }
        

    }


}
