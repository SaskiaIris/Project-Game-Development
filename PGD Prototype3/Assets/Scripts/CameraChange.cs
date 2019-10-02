using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook Camera;
    public Cinemachine.CinemachineFreeLook Camera2;

    public bool HideCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        if(HideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Camera.Priority = 9;
            Camera2.Priority = 10;
            GameObject.Find("YBot").GetComponent<MovementInput>().enabled = false;
            GameObject.Find("YBot").GetComponent<Gather>().enabled = false;
            GameObject.Find("TreeEnt").GetComponent<TreeEntController>().enabled = true;
            GameObject.Find("TreeEnt").GetComponent<MovementInput>().enabled = true;
        }

        if (Input.GetKey(KeyCode.X))
        {
            Camera.Priority = 10;
            Camera2.Priority = 9;
            GameObject.Find("YBot").GetComponent<MovementInput>().enabled = true;
            GameObject.Find("YBot").GetComponent<Gather>().enabled = true;
            GameObject.Find("TreeEnt").GetComponent<TreeEntController>().enabled = false;
            GameObject.Find("TreeEnt").GetComponent<MovementInput>().enabled = false;
        }

    }
}

