using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    NavMeshAgent nav;

    AnimationControllerCharacter anim;

    void Start()
    {
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
    }
}
