using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    string algorithm = "gakdgakgjcgjciaibkijadfgjadhbedhchbfibhjaibdgcijbkeeegaickficffk";

    public Grid grid;

    public List<GameObject> pipes;

    void Start()
    {
        pipes = new List<GameObject>();
       
    }



    void RotatePipe(GameObject pipe, float rotation)
    {
        pipe.transform.eulerAngles = new Vector3(0,0,rotation);
    }



}
