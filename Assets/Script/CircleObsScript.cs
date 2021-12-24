using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObsScript : MonoBehaviour
{
    public GameObject players;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody >();
        players = FindObjectOfType<BallPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, players.transform.position) < 35)
        {
            rb.AddTorque(-Vector3.forward * -10);
        }
    }
}
