using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_DanceFloor : MonoBehaviour
{
    private Material mat;
    private bool collision;

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        collision = true;
    }

    public void set_pieds_coord(Vector3 piedG_pos, Vector3 piedD_pos)
    {
        mat.SetVector("piedG", piedG_pos);
        mat.SetVector("piedD", piedD_pos);
    }

    public void set_cols(Color centre, Color points, Color fond)
    {
        mat.SetColor("col_centre", centre);
        mat.SetColor("col_points", points);
        mat.SetColor("col_fond", fond);
    }

}
