using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_DanceFloor_CTRL : MonoBehaviour
{
    public script_DanceFloor[] liste_DanceFloors;
    public GameObject piedG, piedD;
    public script_musique musique;
    public Color col_centre_GAGNE, col_points_GAGNE, col_fond_GAGNE;
    public Color col_centre_PERDU, col_points_PERDU, col_fond_PERDU;

    private bool on = true;
    private float timer = 0f;
    
    void Start()
    {
        On();
    }

    void Update()
    {
        timer += musique.volume * .02f;
        Color col_centre = Color.HSVToRGB(Mathf.PingPong(timer + 0.5f, .6f) + .2f, 1f, 1f);
        Color col_points = Color.HSVToRGB(Mathf.PingPong(timer, .6f) + .2f, 1f, 1f);
        Color col_fond = Color.HSVToRGB(Mathf.PingPong(timer, .6f) + .2f, 0.2f, 0.5f);
        float taille = 0.8f + musique.volume * 2f;

        foreach(script_DanceFloor DanceFloor in liste_DanceFloors)
        {
            DanceFloor.set_pieds_coord(piedG.transform.position, piedD.transform.position);
            DanceFloor.set_taille_points(taille);
            if(on)
                DanceFloor.set_cols(col_centre, col_points, col_fond);
        }
    }
    public void On()
    {
        on = true;
        //foreach (script_DanceFloor DanceFloor in liste_DanceFloors)
        //{
        //    DanceFloor.set_cols(col_centre_GAGNE, col_points_GAGNE, col_fond_GAGNE);
        //}
    }
    public void Off()
    {
        on = false;
        foreach (script_DanceFloor DanceFloor in liste_DanceFloors)
        {
            DanceFloor.set_cols(col_centre_PERDU, col_points_PERDU, col_fond_PERDU);
        }
    }
}
