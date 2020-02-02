using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    NavMeshAgent nav;

    AnimationControllerCharacter anim;

    public List<Vector3> leaks;

    public bool canHit;

    void Start()
    {
        leaks = new List<Vector3>();
        anim = GetComponent<AnimationControllerCharacter>();
        nav = GetComponent<NavMeshAgent>();
    } 
  
    public void MoveTo(Vector3 endPos)
    {
        anim.SetAnimationToPlay("IsRunning", true);
        nav.SetDestination(endPos);
        
    }
    private void Update()
    {   
        if(nav.destination.Equals(transform.position))
        {
            anim.SetAnimationToPlay("IsRunning", false);
        }
        foreach (var l in leaks)
        {


            if (Vector3.Distance(transform.position, l) < .3f)
            {
                leaks.Remove(l);
                canHit = true;
            }
        }
    }
    public void HitPipe()
    {
        if (!canHit) return;
        anim.SetAnimationToPlay("IsHitting", true);
        StartCoroutine("StopHitting");
    }
    IEnumerator StopHitting()
    {
        yield return new WaitForSecondsRealtime(.2f);
        anim.SetAnimationToPlay("IsHitting", false);
    }


}
