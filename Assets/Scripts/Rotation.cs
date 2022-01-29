using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float force ;

    void Update()
    {
        transform.Rotate(Vector3.up * force);

    }
}
