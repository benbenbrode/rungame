using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    int Jumpck = 0;
    int jumpnum = 2;
    public float jumpPower;
    
    public float speed = 20.0f;

    public Animator anim;

    int dieck = 0;

    public GameObject Bullet;
    public Transform FirePoint;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        if (dieck == 0)
        {
            if (jumpnum == 0)
            {
                Jumpck = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Jumpck == 1)
                {
                    rigid.velocity = Vector2.zero;
                    rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                    jumpnum--;

                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject instance = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
                instance.transform.SetParent(FirePoint);
            }

        }

        if (dieck == 1)
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }



    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.tag == "ground")
        {
            Jumpck = 1;
            jumpnum = 2;

        }

        if (other.gameObject.tag == "enem")
        {
            anim.SetInteger("life", 0);
            dieck = 1;
        }

    }




}
