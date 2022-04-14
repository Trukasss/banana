using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_DanceFloor : MonoBehaviour
{
    private Material mat;
    private bool collision = false;

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        //collision = true;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
            collision = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
            collision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            collision = false;
    }

    public void set_taille_points(float taille)
    {
        mat.SetFloat("points_mult", taille);
    }

    public void set_pieds_coord(Vector3 piedG_pos, Vector3 piedD_pos)
    {
        if (collision)
        {
            mat.SetVector("piedG", piedG_pos);
            mat.SetVector("piedD", piedD_pos);
        }
        else
        {
            mat.SetVector("piedG", new Vector3(-999, -999, -999));
            mat.SetVector("piedD", new Vector3(-999, -999, -999));
        }
    }

    public void set_cols(Color centre, Color points, Color fond)
    {
        mat.SetColor("col_centre", centre);
        mat.SetColor("col_points", points);
        mat.SetColor("col_fond", fond);
    }

}
