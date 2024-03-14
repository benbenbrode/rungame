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
        // x포지션을 조금씩 이동
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);

        // 목표 지점에 도달했다면
        if (transform.position.x >= endPosition)
        {
            ScrollEnd();
        }

       
    }

    void ScrollEnd()
    {
        Destroy(gameObject); // 제거
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enem") // 적이나 함정에 충돌시
        {
            Destroy(gameObject); // 제거
        }

    }


}

