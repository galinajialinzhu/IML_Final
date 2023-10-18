using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnTouch : MonoBehaviour
{
    public GameObject[] objectsToShow; // 在Inspector中设置要显示的物体

    private void OnTriggerEnter(Collider other)
    {
        // 当有物体进入触发器时，显示所有的objectsToShow
        foreach (var obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }
}
