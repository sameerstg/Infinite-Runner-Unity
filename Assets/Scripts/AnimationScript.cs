using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public static AnimationScript _instance;
    public Animator anim;
    private void Awake()
    {
        _instance = this; 
    }
    public void TriggerRunning()
    {
        anim.SetTrigger("run");
    }
    public void TriggerJump()
    {
        anim.SetTrigger("jump");
    }
    public void TriggerSlide()
    {
        anim.SetTrigger("slide");
    }
}
