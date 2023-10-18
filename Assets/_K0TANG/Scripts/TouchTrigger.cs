using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public GameObject touchingObject;      // 要触碰的目标物体

    public GameObject[] objectsToShowOnFirstTouch;   // 第一次触碰时要显示的物体
    public GameObject[] objectsToHideOnFirstTouch;   // 第一次触碰时要隐藏的物体

    public GameObject[] objectsToShowOnSecondTouch;  // 第二次触碰时要显示的物体
    public GameObject[] objectsToHideOnSecondTouch;  // 第二次触碰时要隐藏的物体

    public GameObject[] objectsToShowOnThirdTouch;  // 第三次触碰时要显示的物体
    public GameObject[] objectsToHideOnThirdTouch;  // 第三次触碰时要隐藏的物体

    private int touchCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == touchingObject)
        {
            touchCount++;

            switch(touchCount)
            {
                case 1:
                    foreach (GameObject obj in objectsToShowOnFirstTouch)
                    {
                        obj.SetActive(true);
                    }
                    foreach (GameObject obj in objectsToHideOnFirstTouch)
                    {
                        obj.SetActive(false);
                    }
                    break;
                
                case 2:
                    foreach (GameObject obj in objectsToShowOnSecondTouch)
                    {
                        obj.SetActive(true);
                    }
                    foreach (GameObject obj in objectsToHideOnSecondTouch)
                    {
                        obj.SetActive(false);
                    }
                    break;
                    
                case 3:
                    foreach (GameObject obj in objectsToShowOnThirdTouch)
                    {
                        obj.SetActive(true);
                    }
                    foreach (GameObject obj in objectsToHideOnThirdTouch)
                    {
                        obj.SetActive(false);
                    }
                    break;

                // 如果有更多的触碰行为，可以继续添加case
            }
        }
    }
}


