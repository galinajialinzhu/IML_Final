using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuoMian : MonoBehaviour
{
    public GameObject PinkPowder;
    public GameObject Bowl, Water, Flour, oil, MianTuan, Spoon, HandL,HandR,CaiBan,MianTuan2;
    private GameObject Dect1,Dect2,Dect3,Dect4;
    public Material EmptyColor, WaterColor,PinkColor;
    private Vector3 lastPosition;
    private float speed;
    //step 1:白水，step2：粉水，step3：面团
    private string State,Step;

    private bool AddWater,AddPinkPowder,Mix;



    // Start is called before the first frame update
    void Start()
    {
        Step ="1";
        AddPinkPowder = false;
        AddWater = false;
        Mix = false;
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
        if((AddWater == true)&&(AddPinkPowder = true)&&(Mix == true)){
            Step = "3";
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
            MianTuan.transform.localScale = new Vector3(0.2f, 0.2f, 0.8f);
        }

        if((State =="MeiHao")&&(MianTuan.transform.position.y >0.5f))
        {
            //grabbable can change it transformer
            print("lie");
            MianTuan.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            MianTuan.transform.position = HandL.transform.position;
            ToggleObjectVisibility(MianTuan2);
            MianTuan2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            MianTuan2.transform.position = HandR.transform.position;

        }
    }

    void ToggleObjectVisibility(GameObject targetMian)
    {
        // Check if the target object has a Renderer component
        Renderer mianRenderer = targetMian.GetComponent<Renderer>();
        if (mianRenderer != null)
        {
            // Toggle the visibility of the target object
            mianRenderer.enabled = !mianRenderer.enabled;
        }
    }

            
    void OnCollisionEnter(Collision collision)
    {
        //检测有没有加入水到碗里
        if (collision.gameObject == Water)
        {
            AddWater = true;
            print("add water");
            MianTuan.GetComponent<Renderer>().material = WaterColor;
            Destroy(Water);
        }

        //检测有没有加入颜色粉到碗里
        if (collision.gameObject == PinkPowder)
        {
            AddPinkPowder = true;
            print("add powder");
            //MianTuan.GetComponent<Renderer>().material = PinkColor;
            Destroy(PinkPowder);
        }

        //检测有没有搅拌
        if (collision.gameObject == Spoon)
        {
            Mix = true;
            print("Mix");
            MianTuan.GetComponent<Renderer>().material = PinkColor;
            
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
        
  
    
}



