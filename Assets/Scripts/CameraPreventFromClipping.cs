using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreventFromClipping : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 cameraStartPosition;
    public GameObject characterHead;
    private float distance;

    private void Start()
    {

        mainCam = Camera.main;

        cameraStartPosition = transform.localPosition;

        distance = Vector3.Distance(mainCam.transform.position, characterHead.transform.position);
    }
    private void Update()
    {
        Vector3 direction = (characterHead.transform.position - cameraStartPosition).normalized;
        if (Physics.Raycast(characterHead.transform.position,direction, out RaycastHit hit ))
        {
            mainCam.transform.position = hit.point;
            mainCam.transform.localPosition += new Vector3(0, 0, 0.1f);
        }
    }



}
