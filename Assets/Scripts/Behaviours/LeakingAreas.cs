using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakingAreas : MonoBehaviour
{

    public GridDisplay gridDisplay;

    public List<int> areasWithLeakage;

    float timeBetweenLeaks = 5f;

    public GameObject waterVFX;

    public List<int> RequiredInputs;

    public CharacterMovements character;

    public AnimationControllerCharacter anim;

    MidiOutTest output;

    AudioSource hitSound;
    
    void Start()
    {
        output = GetComponent<MidiOutTest>();
        hitSound = GetComponent<AudioSource>();
        hitSound.playOnAwake = false;
        hitSound.loop = false;
        RequiredInputs = new List<int>();
        areasWithLeakage = new List<int>();
        StartCoroutine(StartLeaking());
    }
    IEnumerator StartLeaking()
    {
        int total = 0;
        yield return new WaitForSeconds(timeBetweenLeaks);
        while(total <10)
        {
            
                var leakingCell =  gridDisplay.grid.GetRandomLeakingArea();
                
                
                areasWithLeakage.Add(leakingCell);
                Signalize(leakingCell);
                total++;
            
            yield return new WaitForSeconds(timeBetweenLeaks);
        }
    }
    public void StopLeakage(int cell)
    {
        Debug.Log("LEAKAGE STOPPED!");
        areasWithLeakage.Remove(cell);
    }
    void Signalize(int leakingCell)
    {
        GameObject go = Instantiate(waterVFX) as GameObject;
        int x = leakingCell / 8;
        int y = leakingCell % 8;
        output.VisualSignal((x*16+y), go);
        RequiredInputs.Add(x);
        RequiredInputs.Add(y);
        Debug.Log($"{x}, {y}");
        go.transform.position = gridDisplay.grid.GetWorldPosition(x,y);
        Debug.Log(leakingCell.ToString());
    }
    public void StopLeakInputs(int inputX, int inputY)
    {
        if (!character.canHit) return;
        for(int i =0;i<RequiredInputs.Count;i+=2)
        {
            if(RequiredInputs[i]== inputX && RequiredInputs[i+1] == inputY)
            {
                hitSound.Play();
                anim.SetAnimationToPlay("IsHitting", true);
                StartCoroutine("StopHitting");
            }
        }
    }
    IEnumerator StopHitting()
    {
        GameObject currentLeak = null;
        GameObject[] leaks = GameObject.FindGameObjectsWithTag("WaterVFX");
        Debug.Log($"{leaks.Length} leaks");
        yield return new WaitForSecondsRealtime(.2f);
        anim.SetAnimationToPlay("IsHitting", false);
        yield return new WaitForSeconds(1.15f);
        foreach (var l in leaks)
        {
            if (Vector3.Distance(l.transform.position, character.gameObject.transform.position) <= .3f) Destroy(l,3);
        }
        
    }
}
