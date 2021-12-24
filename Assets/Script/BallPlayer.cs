using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallPlayer : MonoBehaviour
{
    public ParticleSystem particleEffectWater;
    public float upspeed;
    public float speed;
    public float powerTime;
    public float maxPosY;

    GameObject ballChilObj;
    Rigidbody rb;

    Vector3 dir;
    Vector3 posY;

    float timer;
    float timerZero;
    bool isFinishPower;
    bool isPlayParticle;
    public bool isFail;
    public bool startGame;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        ballChilObj = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        if(startGame)
        {
            dir = transform.GetChild(0).transform.position - transform.GetChild(1).transform.position;
            if (Input.GetMouseButton(0))
            {
                if (timer < powerTime)
                {
                    timer = timer + Time.deltaTime;
                    BallMovementUp();
                }
                else
                {
                    isFinishPower = true;
                    BallMovementForward();
                }
            }
            else
            {
                BallMovementForward();
                timer = 0;
            }
            if (isFinishPower)
            {
                CheckPowerTime();
            }

            if (isFail)
            {
                BallBompFail();

            }
            else
            {
                posY = transform.position;
                posY.y = Mathf.Clamp(transform.position.y, -100, maxPosY);
                transform.position = posY;
            }
        }
    }

    public void BallMovementForward()
    {
        rb.AddTorque(-Vector3.forward * speed);

        if (isPlayParticle)
        {
            isPlayParticle = false;
            particleEffectWater.Stop();
        }
    }
    public void BallMovementUp()
    {
        rb.AddForce(dir * upspeed);
        if (!isPlayParticle)
        {
            isPlayParticle = true;
            particleEffectWater.Play();
        }
    }
    public void CheckPowerTime()
    {
        if (timerZero < 2)
        {
            timerZero = timerZero + Time.deltaTime;
        }
        else
        {
            isFinishPower = false;
            timerZero = 0;
            timer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            BallBounces();
            timer = 0;
        }
        if (collision.transform.CompareTag("brokenglass"))
        {
            collision.transform.GetComponent<Collider>().enabled = false;
            collision.transform.GetComponent<MeshRenderer>().enabled = false;
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("jar"))
        {
            other.GetComponent<Collider>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(false);
            other.transform.GetChild(2).gameObject.SetActive(true);
        }
        if (other.CompareTag("diken"))
        {
            isFail = true;
            GetComponent<BlendShapeScript>().isFail = true;
            GetComponent<BlendShapeScript>().Invoke("cameraBlock", 2f);
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Air"))
        {
            rb.AddForce(Vector3.up * upspeed/2);
        }
    }
    public void BallBompFail()
    {
        BallMovementForward();
        BallMovementUp();
        rb.AddForce(Vector3.up * upspeed/2);
    }

    public void BallBounces()
    {
        ballChilObj.transform.DOScale(new Vector3(1f, 0.9f, 0.9f), 0.1f).OnComplete(() => ballChilObj.transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }
}
