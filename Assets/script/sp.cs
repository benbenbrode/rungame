using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class sp : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("sw", time, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void sw() 
    {
        GameObject instance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        instance.transform.SetParent(spawnPoint);
    }
}
