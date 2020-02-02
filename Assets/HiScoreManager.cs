using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScoreManager : MonoBehaviour
{
    



    void Start()
    {
        transform.LookAt(Camera.main.transform);
        gameObject.GetComponent<Animator>().SetBool("IsDancing", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
