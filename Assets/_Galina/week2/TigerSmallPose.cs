using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerSmallPose : MonoBehaviour
{
    public GameObject DetectBall;
    public int numberOfObjects;
    public float x, y, z;
    public List<GameObject> locate = new List<GameObject>();
    public Material LaterColorBall, NextColorBall;

    // Start is called before the first frame update
    void Start()
    {
        //locate.Add(Instantiate(DetectBall, new Vector3(0, 0, 0), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TigerHandUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TigerHandDown();
        }
    }

    void TigerHandUp()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newObject = Instantiate(DetectBall);
            locate.Add(newObject);
            locate[i].transform.position = new Vector3(0, y, z);
            y += 0.1f;
            z = (1.0f / 2.0f) * y * y - y + 1;
        }
    }

    void TigerHandDown()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject newObject = Instantiate(DetectBall);
            locate.Add(newObject);
            locate[i].transform.position = new Vector3(0, y, z);
            y += 0.01f;
            z = (1.0f / 2.0f) * y * y - y + 1;
        }

    }
}
