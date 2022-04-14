using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class script_GameMaster : MonoBehaviour
{
    //VARIABLES
    public TextMeshProUGUI txt_temps;
    public TextMeshProUGUI txt_score;
    public script_Vie_CTRL vies_CTRL;
    public script_DanceFloor_CTRL danceFloors_CTRL;
    public shooting gunner;

    private bool gameover = false;
    private int min, sec, mil; //temps
    private int nb_vies = 3;

    void Start()
    {
        AfficherScore();
    }

    void Update()
    {
        //Score
        if (!gameover)
        {
            AfficherTemps();
        }
    }

    public void Degat()
    {
        nb_vies -= 1;
        var liste_bananes = FindObjectsOfType<GameObject>();
        foreach(GameObject go in liste_bananes)
        {
            if(go.layer == 8)
            {
                Destroy(go);
            }
        }

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
        PlayerPrefs.SetFloat("currentscore", Time.time);
        float score_sauv = PlayerPrefs.GetFloat("highscore");
        float score_actu = PlayerPrefs.GetFloat("currentscore");
        if (score_actu > score_sauv)
        {
            PlayerPrefs.SetFloat("highscore", score_actu);
            AfficherScore();
        }
        Debug.Log("GameOver");
    }

    IEnumerator Ivulnerabilite(float seconds, bool reset)
    {
        gunner.Bloquer();
        danceFloors_CTRL.Off();
        vies_CTRL.Mort_debut(nb_vies);
        yield return new WaitForSeconds(seconds);
        vies_CTRL.Mort_fin(nb_vies);
        if (reset)
        {
            danceFloors_CTRL.On();
            gunner.Debloquer();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
