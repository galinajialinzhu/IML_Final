using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    public float pourThresholdAngle = 45f;  // 超过这个角度开始倒
    public GameObject content;              // 里面的东西
    public Vector3 pourDirection = new Vector3(0, -1, 0);  // 倒出的方向

    private bool isPouring = false;         // 是否正在倒出

    void Update()
    {
        // 检查物体是否旋转超过指定角度
        if (Vector3.Dot(transform.up, Vector3.up) < Mathf.Cos(pourThresholdAngle * Mathf.Deg2Rad) && !isPouring)
        {
            StartCoroutine(PourContents());
        }
    }

    IEnumerator PourContents()
    {
        isPouring = true;
        
        // 这里可以添加你自己的倒出效果逻辑
        // 下面是一个简单的示例，直接移动里面的东西：
        float pourSpeed = 0.5f;
        while (Vector3.Dot(transform.up, Vector3.up) < Mathf.Cos(pourThresholdAngle * Mathf.Deg2Rad))
        {
            content.transform.position += pourDirection * pourSpeed * Time.deltaTime;
            yield return null;
        }
        
        isPouring = false;
    }
}
