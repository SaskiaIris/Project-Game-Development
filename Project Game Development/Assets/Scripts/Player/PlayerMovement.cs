using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 5f;
    public ArrayList detectedByGuards = new ArrayList();
    public bool isInDisguiseRoom = false;
    public bool hasBeenDetected = false;

    private SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Disguise room")
        {
            isInDisguiseRoom = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Disguise room")
        {
            isInDisguiseRoom = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0, -turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, turnSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.X) && detectedByGuards.Count > 0)
        {
            AlertGuards();
        }

        if (Input.GetKey(KeyCode.E) && isInDisguiseRoom && hasBeenDetected)
        {
            CalmGuards();
            spriteRenderer.color = Random.ColorHSV();
        }
    }

    public void AlertGuards()
    {
        hasBeenDetected = true;
        foreach (GameObject Cone in GameObject.FindGameObjectsWithTag("Cone"))
        {
            Cone.GetComponent<SpriteRenderer>().sprite = Cone.GetComponentInParent<GuardController>().coneDetected;
        }
    }

    public void CalmGuards()
    {
        hasBeenDetected = false;
        foreach (GameObject Cone in GameObject.FindGameObjectsWithTag("Cone"))
        {
            Cone.GetComponent<SpriteRenderer>().sprite = Cone.GetComponentInParent<GuardController>().coneUndetected;
        }
    }
}
