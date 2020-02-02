using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakingAreas : MonoBehaviour
{

    public GridDisplay gridDisplay;

    public List<int> areasWithLeakage;

    float timeBetweenLeaks = 5f;
    
    void Start()
    {
        areasWithLeakage = new List<int>();
        StartCoroutine(StartLeaking());
    }
    IEnumerator StartLeaking()
    {
        yield return new WaitForSeconds(timeBetweenLeaks);
        while(true)
        {
            if(areasWithLeakage.Count<2)
            {
                var leakingCell =  gridDisplay.grid.GetRandomLeakingArea();
                Debug.Log("leaking area "+leakingCell);
                areasWithLeakage.Add(leakingCell);
                Signalize(leakingCell);
            }
            yield return new WaitForSeconds(timeBetweenLeaks);
        }
    }
    public void StopLeakage(int cell)
    {
        areasWithLeakage.Remove(cell);
    }
    void Signalize(int leakingCell)
    {
        Debug.Log(leakingCell.ToString());
    }
}
