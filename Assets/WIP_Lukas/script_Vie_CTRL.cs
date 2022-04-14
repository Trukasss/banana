using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Vie_CTRL : MonoBehaviour
{
    public GameObject[] go_vies;
    private script_Vie[] scripts_vies;
    public Color col_rouge;
    public Color col_noir;

    // Start is called before the first frame update
    void Start()
    {
        scripts_vies = new script_Vie[go_vies.Length];

        for (int i = 0; i < scripts_vies.Length; i++)
        {
            scripts_vies[i] = go_vies[i].GetComponent<script_Vie>();
        }
    }

    public void Mort_debut(int index)
    {
        scripts_vies[index].Changer_couleur(col_rouge);
        scripts_vies[index].Arreter_animation();
        scripts_vies[index].Jouer_son();
    }
    public void Mort_fin(int index)
    {
        scripts_vies[index].Changer_couleur(col_noir);
    }
}
