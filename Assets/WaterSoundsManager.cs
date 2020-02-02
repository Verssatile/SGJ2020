using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundsManager : MonoBehaviour
{
    AudioSource waterStream;
    // Start is called before the first frame update
    void Start()
    {
        waterStream = GetComponent<AudioSource>();
        waterStream.Play();
        waterStream.loop = true;
        waterStream.volume = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
