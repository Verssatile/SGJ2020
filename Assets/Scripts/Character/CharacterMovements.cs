using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovements : MonoBehaviour
{
    private float speed = 1f;

    private Rigidbody rb;

    NavMeshAgent nav;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        nav = GetComponent<NavMeshAgent>();
    }
    #region rigidbody usage
    private void Move(Vector3 direction)
    {
        
        rb.MovePosition(transform.position + direction*Time.deltaTime);
    }
    #endregion
    #region navmesh usage
    private void MoveWithNavMesh(Vector3 endPos)
    {
        nav.SetDestination(endPos);
    }


    #endregion
}
