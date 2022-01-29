using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncoin : MonoBehaviour
{
    public int maxcoins;

    public GameObject obj;
    void Start()
    {
        for (int i = 0; i < maxcoins; i++)
        {
            var x = Random.Range(-1, 2);
            Instantiate(obj, new Vector3(x*5f, 4, i * 20),Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
