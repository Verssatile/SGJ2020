using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreventFromClipping : MonoBehaviour
{
    public GameObject Head;
    RaycastHit hit;
    private GameObject MainCamera;
    public Vector3 CameraStartPosition;
    public GameObject TestForHit;
    Quaternion CamStartRot;
    public float Distance;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main.gameObject;
        Distance = Vector3.Distance(CameraStartPosition, gameObject.transform.position);
        CamStartRot = MainCamera.transform.localRotation;
        CameraStartPosition = MainCamera.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {

        if (HasHit())
        {

            //SetCameraNewPosition(hit.point + new Vector3(0, 0, -0.001f));
            //local transform position
            Debug.Log(hit.collider);
            SetCameraNewPosition(hit.point + new Vector3(0, 0, -0.001f));
        }
        else
        {
            RessCameraPosition();
        }

    }
    void SetCameraNewPosition(Vector3 NewPosition)
    {
        if (Vector3.Distance(gameObject.transform.position, NewPosition) > Vector3.Distance(gameObject.transform.position, TestForHit.transform.position))
        {
            return;
        }
        MainCamera.transform.LookAt(Head.transform.position);
        MainCamera.transform.position = NewPosition;
        MainCamera.transform.localPosition += new Vector3(0, 0, 0.025f);
    }
    void RessCameraPosition()
    {
        MainCamera.transform.localPosition = CameraStartPosition;
        MainCamera.transform.localRotation = CamStartRot;
    }

    bool HasHit()
    {
        Vector3 StartLoc = Head.transform.position;
        Vector3 EndLoc = TestForHit.transform.position;
        Vector3 direction = (EndLoc - StartLoc).normalized;
        return (Physics.Raycast(StartLoc, direction, out hit));

    }
    void DrawLines(Vector3 StartLoc, Vector3 EndLoc)
    {
        Vector3 direction = (EndLoc - StartLoc);
        Debug.DrawRay(StartLoc, direction);

    }


}
