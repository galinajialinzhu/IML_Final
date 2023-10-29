using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeOnCollision : MonoBehaviour
{
    public GameObject targetObject;     // 指定的物体
    public Vector3 resizeFactor = new Vector3(0.5f, 0.5f, 0.5f);  // 缩放因子，基于当前的scale
    public Vector3 minScale = new Vector3(0.1f, 0.1f, 0.1f);       // 最小的scale

    private void OnCollisionEnter(Collision collision)
    {
        // 检查是否碰撞到了指定的物体
        if (collision.gameObject == targetObject)
        {
            // 基于当前的缩放值，对每个轴分别调整scale
            Vector3 currentScale = targetObject.transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x * resizeFactor.x, currentScale.y * resizeFactor.y, currentScale.z * resizeFactor.z);

            // 确保新的scale不小于设定的最小scale
            newScale = Vector3.Max(newScale, minScale);

            targetObject.transform.localScale = newScale;
        }
    }
}



