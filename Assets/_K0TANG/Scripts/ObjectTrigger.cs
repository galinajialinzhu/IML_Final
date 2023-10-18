using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public GameObject[] triggerObjects;     // 指定的四个物体
    public GameObject objectToShow;         // 当四个物体都在区域内时要显示的物体
    public GameObject[] objectsToHide;      // 当四个物体都在区域内时要隐藏的物体

    private int objectCount;

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject obj in triggerObjects)
        {
            if (obj == other.gameObject)
            {
                objectCount++;
                CheckAllObjectsInTrigger();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach(GameObject obj in triggerObjects)
        {
            if (obj == other.gameObject)
            {
                objectCount--;
            }
        }
    }

    private void CheckAllObjectsInTrigger()
    {
        if (objectCount == triggerObjects.Length)
        {
            objectToShow.SetActive(true);
            foreach(GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }
        }
    }
}
