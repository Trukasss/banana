using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banane : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed=0f;
    private float Speed_Time;
    private bool canLaunch = false;

    public Transform top_banane;
    public Transform middle_banane;
    public Transform bot_banane;

    public Transform end_Banane;

    public Vector3 scaleChange = new Vector3(0.1f,0,0);

    public void Growth(float sizeBanana)
    {
        middle_banane.localScale = new Vector3(2 +sizeBanana,2,2);
        top_banane.transform.position = end_Banane.position; 
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed_Time = Speed;

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void Launch()
    {
        canLaunch = true;
    }

    void FixedUpdate()
    {
        if (canLaunch)
        {
            rb.velocity = new Vector3(0, 0, Speed_Time);

        }
    }
}
