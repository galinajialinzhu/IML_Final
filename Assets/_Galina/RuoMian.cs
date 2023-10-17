using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuoMian : MonoBehaviour
{
    public GameObject Bowl, Water, Flour, MianTuan, Spoon, HandL,HandR,CaiBan;
    //public GameObject Dect1,Dect2,Dect3,Dect4;
    private Vector3 lastPosition;
    public float speed;
    private string State;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        DectectIfRouMianDone();



        if ((Vector3.Distance(HandL.transform.position, HandR.transform.position)>2))
        {
            print("hi");

        }
    
    }

    void DectectIfRouMianDone()
    {
        //计算面团下落速度
        Vector3 displacement = transform.position - lastPosition;
        speed = displacement.magnitude / Time.deltaTime;
        lastPosition = transform.position;
    }

            
    void OnCollisionEnter(Collision collision)
    {
        //print("hi");
        if ((speed > 0.5) &&( collision.gameObject == CaiBan))
        {
            State ="Haole";
        }
        else if ((speed < 0.5) && (collision.gameObject == CaiBan))
        {
            State ="MeiHao";
        }
    }
        




    
    
    
}



