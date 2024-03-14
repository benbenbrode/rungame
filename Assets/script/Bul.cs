using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bul : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    public float endPosition = 10.0f;

    void Update()
    {
        // x�������� ���ݾ� �̵�
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);

        // ��ǥ ������ �����ߴٸ�
        if (transform.position.x >= endPosition)
        {
            ScrollEnd();
        }

       
    }

    void ScrollEnd()
    {
        Destroy(gameObject); // ����
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enem") // ���̳� ������ �浹��
        {
            Destroy(gameObject); // ����
        }

    }


}

