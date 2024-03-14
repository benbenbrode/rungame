using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed = 1.0f;
    public float endPosition;

    void Update()
    {
        // x�������� ���ݾ� �̵�
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // ��ǥ ������ �����ߴٸ�
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
