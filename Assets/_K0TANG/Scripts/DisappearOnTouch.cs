using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    public GameObject objectToDisappear;  // 物体2，在Inspector中设置

    private void OnTriggerEnter(Collider other)
    {
        // 当物体1与物体2碰撞时，隐藏物体2
        if (other.gameObject == objectToDisappear)
        {
            objectToDisappear.SetActive(false);
        }
    }
}



