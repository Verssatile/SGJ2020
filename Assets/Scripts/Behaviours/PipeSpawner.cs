using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    string algorithm = "gakdgakgjcgjciaibkijadfgjadhbedhchbfibhjaibdgcijbkeeegaickficffk";

    public GridDisplay gridDisplay;

    public List<GameObject> pipes;

    void Start()
    {
        pipes = Resources.LoadAll("Pipes").Cast<GameObject>().ToList();
        FillLevelWithPipes();
       
    }
    void FillLevelWithPipes()
    {
        int x = 0;
        int y = 0;
        for(int i =0;i<algorithm.Length;i++)
        {
            GameObject spawned = Instantiate(GetPipeByName(algorithm[i].ToString())) as GameObject;
            spawned.transform.position = gridDisplay.grid.GetWorldPositionPipe(x, y);
            spawned.transform.parent = transform;
            x++;
            if (x>=8)
            {
                x = 0;
                y++;
                continue;
            }
          
        }
    }
    GameObject GetPipeByName(string s)
    {
        foreach(var pipe in pipes)
        {
            if (pipe.name.Equals(s)) return pipe;
        }
        return null;
    }


    void RotatePipe(GameObject pipe, float rotation)
    {
        pipe.transform.eulerAngles = new Vector3(0,0,rotation);
    }



}
