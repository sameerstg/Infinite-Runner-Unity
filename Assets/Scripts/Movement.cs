using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public AnimationScript animationScript;
    public SoundManager soundManager;
    public bool onGround;
    //      Setting of Speed For Translate
    public float tForceforwards;
    public float tForcehorizontals;
    public float tForceupwards;


    //      Limits
    public float leftLimit,rightLimit;
    public bool running = false;
    public Vector3 position;
    public int realTimePos;


    public Text speedText;
    public float speed;


    public CapsuleCollider playerCollider;
    public float colliderHeight, colliderRadius;
    void Start()
    {
        animationScript = AnimationScript._instance;
        soundManager = SoundManager._instance;
        rb = GetComponent<Rigidbody>();
        position = transform.position;
        leftLimit = -tForcehorizontals;
        rightLimit = +tForcehorizontals;
        realTimePos = 0;


        colliderHeight = playerCollider.height;
        colliderRadius = playerCollider.radius;

    }

    private void FixedUpdate()
    {
        StartCoroutine(SpeedCheck());
        if (Input.GetKeyDown(KeyCode.Return))
        {
            running = true;
            animationScript.TriggerRunning();
            soundManager.PlayBackgroundMusic();
        }

        if (running)
        {
            transform.Translate(new Vector3(0, 0, tForceforwards * Time.fixedDeltaTime));
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            transform.Translate(new Vector3(0, tForceupwards, 0));
            animationScript.TriggerJump();
        }
    }
    void Update()
    {


        if (running)
        {
            if (Input.GetKeyDown(KeyCode.A) && realTimePos != -1)
            {

                transform.Translate(new Vector3(-tForcehorizontals, 0, 0));
                realTimePos -= 1;


            }
            if (Input.GetKeyDown(KeyCode.D) && realTimePos != +1)
            {
                transform.Translate(new Vector3(tForcehorizontals, 0, 0));
                realTimePos += 1;

            }

            
            if (Input.GetKeyDown(KeyCode.S))
            {
                animationScript.TriggerSlide();
                StartCoroutine(Slide());

            }

        }
    }
    public IEnumerator Slide()
    {
        playerCollider.radius = .25f;
        playerCollider.height = 0;
        yield return new WaitForSeconds(1.2f);
        playerCollider.height = colliderHeight;
        playerCollider.radius = colliderRadius;

    }
    public IEnumerator SpeedCheck()
    {
        var vi = transform.position.z;
        yield return new WaitForSeconds(1);
        var vf = transform.position.z;
        speed = (vf - vi)/1;
        speedText.text = "Speed: " + speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            GameManager._instance.CollectCoin();
            soundManager.PlayCoinCollectSfx();
        }
        if (other.gameObject.tag == "Hurdle")
        {
            print("Dead");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }


}
