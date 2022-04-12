using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class script_GameMaster : MonoBehaviour
{
    //VARIABLES
    private float score;
    private int min, sec, mil;
    public TextMeshProUGUI txt_score;

    void Start()
    {
        
    }

    void Update()
    {
        mil = (int)(Time.time * 100) % 100;
        sec = (int)(Time.time % 60);
        min = (int)(Time.time / 60) % 60;

        txt_score.SetText("Score: " + min.ToString() + '"' + sec.ToString() + "'" + mil.ToString());
    }
}
