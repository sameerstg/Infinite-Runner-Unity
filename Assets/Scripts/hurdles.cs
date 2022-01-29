using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdles : MonoBehaviour
{
    public GameObject[] objs;
    public int distanceOfHurdles;
    void Start()
    {

        for (int i = 0; i < objs.Length; i++)
        {
            var x = Random.Range(-1, 2);
            x *= 5;
            objs[i].transform.position = new Vector3(x, 0, i * distanceOfHurdles);
        }
    }
}

//-5.5.3