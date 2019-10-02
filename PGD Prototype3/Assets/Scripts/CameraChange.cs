using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook Camera;
    public Cinemachine.CinemachineFreeLook Camera2;

    private int oldPriorityCamera;
    private int oldPriorityCamera2;
    // Start is called before the first frame update
    void Start()
    {
        int oldPriorityCamera = GameObject.Find("ThirdPersonCamera").GetComponent<Cinemachine.CinemachineFreeLook>().Priority;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Camera.Priority = Camera2.Priority;
            Camera2.Priority = oldPriorityCamera;

            oldPriorityCamera = Camera.Priority;
        }
    }
}

