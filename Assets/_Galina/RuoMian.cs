using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuoMian : MonoBehaviour
{
    public GameObject PinkWater,PinkPowder;
    public GameObject Bowl, Water, Flour, MianTuan, Spoon, HandL,HandR,CaiBan;
    private GameObject Dect1,Dect2,Dect3,Dect4;
    public Material EmptyColor, WaterColor,PinkColor;
    private Vector3 lastPosition;
    private float speed;
    //step 1:白水，step2：粉水，step3：面团
    private string State,Step;

    private bool AddWater,AddPinkPowder;



    // Start is called before the first frame update
    void Start()
    {
        Step ="1";
        AddPinkPowder = false;
        AddWater = false;
        MianTuan.GetComponent<Renderer>().material = EmptyColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Step =="1")
        {
            MakePinkWater();
        }
        if(Step =="2")
        {
           MakeMianTuan();
        }
        if(Step =="3")
        {
            DectectIfRouMianDone();
        }
    }

    void MakePinkWater()
    {
        if((AddWater == true)&&(AddPinkPowder = true)){
            Step = "2";
        }
    }

    void MakeMianTuan()
    {
        print("step2");
    }





    void DectectIfRouMianDone()
    {
        //计算面团下落速度
        Vector3 displacement = transform.position - lastPosition;
        speed = displacement.magnitude / Time.deltaTime;
        lastPosition = transform.position;

        if((State =="Haole")&&(MianTuan.transform.position.y >0.5f))
        {
            //grabbable can change it transformer
            print("mo");
        }

        if((State =="MeiHao")&&(MianTuan.transform.position.y >0.5f))
        {
            //grabbable can change it transformer
            print("lie");
        }
    }

            
    void OnCollisionEnter(Collision collision)
    {
        //检测有没有加入碗里
        if (collision.gameObject == Water)
        {
            AddWater = true;
            print("add water");
            MianTuan.GetComponent<Renderer>().material = WaterColor;
            Destroy(Water);
        }

        if (collision.gameObject == PinkPowder)
        {
            AddPinkPowder = true;
            print("add powder");
            MianTuan.GetComponent<Renderer>().material = PinkColor;
            Destroy(PinkPowder);
        }

        if ((speed > 0.5) &&( collision.gameObject == CaiBan))
        {
            State ="Haole";
            print("haole");
        }
        else if ((speed < 0.5) && (collision.gameObject == CaiBan))
        {
            State ="MeiHao";
            print("meihao");
        }
    }
        
    void ChenMian()
    {
        if ((Vector3.Distance(HandL.transform.position, HandR.transform.position)>2))
        {
            print("hi");

        }
    }




    
    
    
}



