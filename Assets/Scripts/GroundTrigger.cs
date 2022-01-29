using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("line"))
        {
            StartCoroutine(Delay(4));
        }
    }

    public IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GroundManager._instance.DestroyFirst();
    }
}
