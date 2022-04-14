using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject Projectile ;
    public Transform[] Canon_array;
    private Banane current;
    private float sizeBanana=1f;
    Transform firstChild;
    public float speed = 50f;

    private bool canFire= true;
    private bool Hold = false;
    public void Fire_Banana(float index, Banane bananeObject)
    {
        bananeObject.Launch();
        canFire = true;
    }
    public Banane Hold_Banana(int index)
    {
        if (canFire)
        {

        }
        Transform Launcher = Canon_array[index];
        GameObject banana = Instantiate(Projectile, Launcher.position, Projectile.transform.rotation);

        Banane bananeScript = banana.GetComponent<Banane>();
        
        Debug.Log(sizeBanana);
        
        sizeBanana = 1f;

        Hold = true;
        canFire = false;
        
        return bananeScript;

    }
    void Start()
    {
        firstChild = GameObject.Find("Gunner").transform.GetChild(0);
        //Canon_array = GetComponentsInChildren<Transform>();
        Debug.Log(Canon_array);
        foreach(Transform child in Canon_array)
        {

            Debug.Log(child);
        }
        
    }

    // Update is called once per frame
    void Update()
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

        if (canFire)
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

       

        if (Hold)
        {
            sizeBanana += Time.deltaTime * speed;

            current.Growth(sizeBanana);
        }




    }
}
