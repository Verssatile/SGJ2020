using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    } 
  
    private void Move(Vector3 endPos)
    {
        nav.SetDestination(endPos);
    }
    
}
