using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement1 : MonoBehaviour
{
    public float forceforwards;
    public float forcehorizontals;
    public float forceupwards;
    public bool running = false;

    void Start()
    {
    
    
    
    
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        { 
            running = true ;
        }
        if (running)
        {
            transform.Translate(Vector3.forward * forceforwards );
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(Vector3.down * forceupwards);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up * forceupwards);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Translate(Vector3.left * forcehorizontals);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(Vector3.right * forcehorizontals);
            }


       
        }
                
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }

}
