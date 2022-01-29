using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationaryhurdles : MonoBehaviour
{
    public GameObject[] objs;
    public int distanceOfRotationaryHurdles;
    public float speed;
    void Start()
    {

        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].transform.position = new Vector3(0, 0, i * distanceOfRotationaryHurdles*20);
        }
 
    }

    void update()
    {
        transform.Rotate(Vector3.up * speed);
    }
}
