using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
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
        // ���� ��ġ�� �ʱ�ȭ ��Ų��.
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
    }
}
