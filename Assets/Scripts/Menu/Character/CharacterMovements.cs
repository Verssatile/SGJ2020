using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    NavMeshAgent nav;

    AnimationControllerCharacter anim;

    public GameObject[] leaks;

    AudioSource movementSound;

    public bool canHit;

    GameObject currentLeak;
    
    public bool CanStopLeak()
    {
        leaks = GameObject.FindGameObjectsWithTag("WaterVFX");
        bool canStopLeak = false;
        foreach (var l in leaks)
        {
            if (Vector3.Distance(transform.position, l.transform.position) < .3f)
            {
                currentLeak = l;
                canStopLeak = true;
            }
        }
        Debug.Log($"canstopleak :{canStopLeak}");
        return canStopLeak;
    }

    void Start()
    {
        movementSound = GetComponent<AudioSource>();
        movementSound.playOnAwake = false;
        movementSound.loop = true;
        anim = GetComponent<AnimationControllerCharacter>();
        nav = GetComponent<NavMeshAgent>();
    } 
  
    public void MoveTo(Vector3 endPos)
    {
        movementSound.Play();
        anim.SetAnimationToPlay("IsRunning", true);
        nav.SetDestination(endPos);
        
    }
    private void Update()
    {   
        if(nav.destination.Equals(transform.position))
        {
            movementSound.Stop();
            anim.SetAnimationToPlay("IsRunning", false);
        }
        foreach (var l in leaks)
        {
            if (l == null) continue;

            if (Vector3.Distance(transform.position, l.transform.position) < .3f)
            {
                currentLeak = l;
                Debug.Log(canHit);
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
        yield return new WaitForSeconds(1.15f);
        foreach(var l in leaks)
        {
            if (Vector3.Distance(l.transform.position, transform.position) <= .3f) currentLeak = l;
        }
        if (currentLeak != null)
        {
            Destroy(currentLeak);
            
        }
    }
}
