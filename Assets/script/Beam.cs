using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed = 1.0f;
    public float endPosition;

    void Update()
    {
        // x포지션을 조금씩 이동
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // 목표 지점에 도달했다면
        if (transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
    }

    void ScrollEnd()
    {
        Destroy(gameObject);
    }
}
