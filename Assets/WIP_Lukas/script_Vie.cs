using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Vie : MonoBehaviour
{
    private SpriteRenderer ren;
    private Animation anim;
    private AudioSource son;

    // Start is called before the first frame update
    void Start()
    {
        ren = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animation>();
        son = this.GetComponent<AudioSource>();
    }

    public void Changer_couleur(Color col)
    {
        ren.color = col;
    }

    public void Arreter_animation()
    {
        //anim.Play();
        anim.Rewind();
        anim.Stop();
    }

    public void Jouer_son()
    {
        son.Play();
    }
}
