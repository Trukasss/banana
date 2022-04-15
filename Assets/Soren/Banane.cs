using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banane : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed=0f;
    private float Speed_Time;
    private bool canLaunch = false;
    public Vector3 scaleChange = new Vector3(0.1f, 0, 0);

    public Transform top_banane;
    public Transform middle_banane;
    public Transform bot_banane;
    public Transform end_Banane;

    //Textures
    public Texture2D[] textures_visage;
    public Texture2D[] textures_corps;

    public void Growth(float sizeBanana)
    {
        middle_banane.localScale = new Vector3(2 +sizeBanana,2,2);
        top_banane.transform.position = end_Banane.position; 
    }
    
    void Start()
    {
        //Textures random
        Texture2D visage = textures_visage[Random.Range(0, textures_visage.Length)];
        Texture2D corps = textures_corps[Random.Range(0, textures_corps.Length)];
        Material material = top_banane.GetChild(0).GetComponent<Renderer>().material;
        material.SetTexture("visage", visage);
        material.SetTexture("corps", corps);
        material.SetFloat("alpha", 1f);
        material = middle_banane.GetChild(0).GetComponent<Renderer>().material;
        material.SetTexture("visage", visage);
        material.SetTexture("corps", corps);
        material.SetFloat("alpha", 0f);
        material = bot_banane.GetChild(0).GetComponent<Renderer>().material;
        material.SetTexture("visage", visage);
        material.SetTexture("corps", corps);
        material.SetFloat("alpha", 0f);


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
