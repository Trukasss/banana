using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_DanceFloor_CTRL : MonoBehaviour
{
    public script_DanceFloor[] liste_DanceFloors;
    public GameObject piedG, piedD;
    public Color col_centre_GAGNE, col_points_GAGNE, col_fond_GAGNE;
    public Color col_centre_PERDU, col_points_PERDU, col_fond_PERDU;
    
    void Start()
    {
        
    }

    void Update()
    {
        foreach(script_DanceFloor DanceFloor in liste_DanceFloors)
        {
            DanceFloor.set_pieds_coord(piedG.transform.position, piedD.transform.position);
        }
        Perdu();
    }
    public void Gagne()
    {
        foreach (script_DanceFloor DanceFloor in liste_DanceFloors)
        {
            DanceFloor.set_cols(col_centre_GAGNE, col_points_GAGNE, col_fond_GAGNE);
        }
    }
    public void Perdu()
    {
        foreach (script_DanceFloor DanceFloor in liste_DanceFloors)
        {
            DanceFloor.set_cols(col_centre_PERDU, col_points_PERDU, col_fond_PERDU);
        }
    }
}
