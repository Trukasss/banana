using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banane : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed=50f;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed_Time = Speed;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Destroyer")
        {
            Debug.Log("je suis detruit");
            Destroy(this.gameObject);
        }
    }
    public void Launch()
    {
        Debug.Log("Lancement de la banane");
        canLaunch = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (canLaunch)
        {
            rb.velocity = new Vector3(0, 0, Speed_Time);

        }
    }
}
