using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class script_GameMaster : MonoBehaviour
{
    //VARIABLES
    public TextMeshProUGUI txt_temps;
    public TextMeshProUGUI txt_score;
    public script_Vie_CTRL vies_CTRL;
    public script_DanceFloor_CTRL danceFloors_CTRL;

    private bool gameover = false;
    private int min, sec, mil; //temps
    private int nb_vies = 3;

    void Start()
    {
        AfficherScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Degat();
            print(nb_vies);
        }

        //Score
        if (!gameover)
        {
            AfficherTemps();
        }
    }

    public void Degat()
    {
        nb_vies -= 1;
        if (nb_vies > 0)
        {
            StartCoroutine(Ivulnerabilite(1f, true));
        }
        else
        {
            StartCoroutine(Ivulnerabilite(1f, false));
            GameOver();
        }
    }

    private void AfficherScore()
    {
        float score = PlayerPrefs.GetFloat("highscore");
        float score_mil = (int)(score * 100) % 100;
        float score_sec = (int)(score  % 60);
        float score_min = (int)(score / 60) % 60;
        txt_score.SetText("Meilleur score : " + score_min.ToString() + '"' + score_sec.ToString() + "'" + score_mil.ToString());
    }

    private void AfficherTemps()
    {
        mil = (int)(Time.time * 100) % 100;
        sec = (int)(Time.time % 60);
        min = (int)(Time.time / 60) % 60;
        txt_temps.SetText(min.ToString() + '"' + sec.ToString() + "'" + mil.ToString());
    }

    private void GameOver()
    {
        gameover = true;
        float score_sauv = PlayerPrefs.GetFloat("highscore");
        float score_actu = Time.time;
        if(score_actu > score_sauv)
        {
            PlayerPrefs.SetFloat("highscore", score_actu);
            AfficherScore();
        }
        Debug.Log("GameOver");
    }

    IEnumerator Ivulnerabilite(float seconds, bool reset)
    {
        danceFloors_CTRL.Off();
        vies_CTRL.Mort_debut(nb_vies);
        yield return new WaitForSeconds(seconds);
        vies_CTRL.Mort_fin(nb_vies);
        if (reset)
            danceFloors_CTRL.On();
    }
}
