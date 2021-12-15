using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallPlayer : MonoBehaviour
{
    public ParticleSystem particleEffectWater;
    public float upspeed;
    public float speed;

    GameObject ballChilObj;
    Rigidbody rb;
    bool isPlayParticle;
    Vector3 dir;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        ballChilObj = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        dir = transform.GetChild(0).transform.position - transform.GetChild(1).transform.position;
        if (Input.GetMouseButton(0))
        {
            BallMovementUp();
        }
        else
        {
            BallMovementForward();
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            BallBounces();
        }
    }
    public void BallBounces()
    {
        ballChilObj.transform.DOScale(new Vector3(1f,0.9f,0.9f),0.1f).OnComplete(()=>ballChilObj.transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }
}
