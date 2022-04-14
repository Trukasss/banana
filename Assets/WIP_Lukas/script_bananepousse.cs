using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_bananepousse : MonoBehaviour
{
    private AudioSource son;
    // Start is called before the first frame update
    void Start()
    {
        son = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Son
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("key down");
            if (!son.isPlaying)
            {
                son.Play();
            }
        }
        else
        {
            son.Stop();
        }
    }
}
