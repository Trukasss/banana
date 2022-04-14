using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_musique : MonoBehaviour
{
    private AudioSource musique;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        musique = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        volume = GetAveragedVolume();
    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        musique.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
