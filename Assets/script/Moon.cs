using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    int Hp = 50; // ä��
    public int patterncker = 5; // ������ ����  0�� ���� ��, 5�� Ž���ϴ� ����

    // ��������Ʈ ������ ���� �Լ�
    public Sprite[] spr; 
    SpriteRenderer spriteRenderer;

    //���� ��ȯ�ϴ� ������ ���� �Լ�
    public GameObject Wall;
    public Transform WallPoint;

    //�������� ��� ������ ���� �Լ�
    public GameObject Be;
    public Transform BePos1;
    public Transform BePos2;
    public Transform BePos3;

    //�ĵ� ������ ���� �Լ�
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
            Debug.Log("1���� ����");

        }

        if (patterncker == 2)
        {
            patterncker = 0;
            StartCoroutine(Beam());
            Debug.Log("2���� ����");

        }

        if (patterncker == 3)
        {
            patterncker = 0;
            StartCoroutine(WaveSw());
            Debug.Log("3���� ����");

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
        if (other.gameObject.tag == "Bullet") // �Ѿ˿� ������
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
        while (a < 3) //3���ݺ�
        {

            spriteRenderer.sprite = spr[1]; //���Ͽ� �´� ��������Ʈ�� ����
            GameObject instance = Instantiate(Wall, WallPoint.position, Quaternion.identity); 
            instance.transform.SetParent(WallPoint);// ����ȯ
            a++;
            yield return new WaitForSeconds(2f); // 2�ʵ�����
        }
        patterncker = 5; //Ž���������� ����
    }

    IEnumerator Beam()
    {
        int a = 0;
        while (a < 3) // 3�� �ݺ�
        {
            spriteRenderer.sprite = spr[2]; //���Ͽ� �´� ��������Ʈ�� ����
            int ran = Random.Range(1, 4); // ������ ��ġ ���� ����
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
            yield return new WaitForSeconds(3f); //3�� ������
        }
        patterncker = 5; //Ž���������� ����
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