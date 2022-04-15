using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject Projectile;
    public Transform[] Canon_array;
    private Banane current;
    private float sizeBanana = 1f;
    Transform firstChild;
    private AudioSource son;
    public GameObject[] Banane;

    public ParticleSystem canon_particle;

    private bool canFire = true;
    private bool Hold = false;
    private bool bloque = false;

    void Start()
    {
        firstChild = GameObject.Find("Gunner").transform.GetChild(0);
        son = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!bloque)
        {
            if (Input.GetKeyUp("left"))
            {
                Fire_Banana(0, current);
            }
            if (Input.GetKeyUp("right"))
            {
                Fire_Banana(1, current);
            }
            if (Input.GetKeyUp("up"))
            {
                Fire_Banana(2, current);
            }
            if (Input.GetKeyUp("down"))
            {
                Fire_Banana(3, current);
            }
            if (Input.GetKeyUp("space"))
            {
                Fire_Banana(4, current);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Fire_Banana(5, current);
            }
        }
        if (canFire && !bloque)
        {
            if (Input.GetKeyDown("left"))
            {
                current = Hold_Banana(0);
            }
            if (Input.GetKeyDown("right"))
            {
                current = Hold_Banana(1);
            }
            if (Input.GetKeyDown("up"))
            {
                current = Hold_Banana(2);
            }
            if (Input.GetKeyDown("down"))
            {
                current = Hold_Banana(3);
            }
            if (Input.GetKeyDown("space"))
            {
                current = Hold_Banana(4);
            }
            if (Input.GetMouseButtonDown(0))
            {
                current = Hold_Banana(5);
            }
        }


        if (Hold && current != null)
        {
            if (!son.isPlaying)
            {
                son.Play();
            }
            sizeBanana += Time.deltaTime * 150f;
            current.Growth(sizeBanana);
        }
        else
        {
            son.Stop();
        }
        //print("canfire : " + canFire.ToString() + ", hold : " + Hold.ToString() + ", bloque : " + bloque.ToString());
    }

    public Banane Hold_Banana(int index)
    {
        Transform Launcher = Canon_array[index];
        Projectile = Banane[Random.Range(0, Banane.Length)];
        GameObject banana = Instantiate(Projectile, Launcher.position, Projectile.transform.rotation);

        Banane bananeScript = banana.GetComponent<Banane>();

        sizeBanana = 1f;
        Hold = true;
        canFire = false;

        return bananeScript;
    }

    public void Fire_Banana(float index, Banane bananeObject)
    {
        if (bananeObject != null)
        {
            bananeObject.Launch();
            canon_particle.Play();
        }
        canFire = true;
        Hold = false;
    }

    public void Bloquer()
    {
        bloque = true;
    }
    public void Debloquer()
    {
        bloque = false;
    }
}
