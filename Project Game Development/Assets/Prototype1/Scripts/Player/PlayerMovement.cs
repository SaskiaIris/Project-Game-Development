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
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, 0);
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
            transform.eulerAngles = new Vector3(0, 0, 90);
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
