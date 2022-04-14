using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_score_fin : MonoBehaviour
{
    public TextMeshProUGUI[] textes_score;

    // Start is called before the first frame update
    void Start()
    {
        float score_actu = PlayerPrefs.GetFloat("currentscore");
        int mil = (int)(score_actu * 100) % 100;
        int sec = (int)(score_actu % 60);
        int min = (int)(score_actu / 60) % 60;

        foreach (TextMeshProUGUI txt_score in textes_score)
        {
            txt_score.SetText(min.ToString() + '"' + sec.ToString() + "'" + mil.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
