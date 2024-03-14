using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    int Hp = 50; // 채력
    public int patterncker = 5; // 패턴의 종류  0은 패턴 중, 5는 탐색하는 패턴

    // 스프라이트 변경을 위한 함수
    public Sprite[] spr; 
    SpriteRenderer spriteRenderer;

    //벽을 소환하는 패턴을 위한 함수
    public GameObject Wall;
    public Transform WallPoint;

    //레이저를 쏘는 패턴을 위한 함수
    public GameObject Be;
    public Transform BePos1;
    public Transform BePos2;
    public Transform BePos3;

    //파도 패턴을 위한 함수
    public GameObject Wave;
    public Transform WavePos;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }

        if (patterncker == 1)
        {
            patterncker = 0;
            StartCoroutine(WallSw());
            Debug.Log("1패턴 시작");

        }

        if (patterncker == 2)
        {
            patterncker = 0;
            StartCoroutine(Beam());
            Debug.Log("2패턴 시작");

        }

        if (patterncker == 3)
        {
            patterncker = 0;
            StartCoroutine(WaveSw());
            Debug.Log("3패턴 시작");

        }

        if (patterncker == 5)
        {
            spriteRenderer.sprite = spr[0];
            Invoke("Think", 5f);
            patterncker = 6;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet") // 총알에 맞을때
        {
            Hp--;
        }

    }

    void Think()
    {
        int ran = Random.Range(1, 4);
        patterncker = ran;
        
    }




    IEnumerator WallSw()
    {
        int a = 0;
        while (a < 3) //3번반복
        {

            spriteRenderer.sprite = spr[1]; //패턴에 맞는 스프라이트로 변경
            GameObject instance = Instantiate(Wall, WallPoint.position, Quaternion.identity); 
            instance.transform.SetParent(WallPoint);// 벽소환
            a++;
            yield return new WaitForSeconds(2f); // 2초딜레이
        }
        patterncker = 5; //탐색패턴으로 변경
    }

    IEnumerator Beam()
    {
        int a = 0;
        while (a < 3) // 3번 반복
        {
            spriteRenderer.sprite = spr[2]; //패턴에 맞는 스프라이트로 변경
            int ran = Random.Range(1, 4); // 레이저 위치 랜덤 지정
            if (ran == 1)
            {
                GameObject instance = Instantiate(Be, BePos1.position, Quaternion.identity);
                instance.transform.SetParent(BePos1);
            }
            else if (ran == 2)
            {
                GameObject instance = Instantiate(Be, BePos2.position, Quaternion.identity);
                instance.transform.SetParent(BePos2);
            }
            else
            {
                GameObject instance = Instantiate(Be, BePos3.position, Quaternion.identity);
                instance.transform.SetParent(BePos3);
            }
            a++;
            yield return new WaitForSeconds(3f); //3초 딜레이
        }
        patterncker = 5; //탐색패턴으로 변경
    }

    IEnumerator WaveSw()
    {
        int a = 0;
        while (a < 3)
        {

            spriteRenderer.sprite = spr[3];
            GameObject instance = Instantiate(Wave, WavePos.position, Quaternion.identity);
            instance.transform.SetParent(WavePos);
            a++;
            yield return new WaitForSeconds(3f);
        }
        patterncker = 5;
    }
}