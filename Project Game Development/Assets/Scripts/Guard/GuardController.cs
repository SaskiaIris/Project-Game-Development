using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    private PlayerMovement player;
    private bool MoveToPoint1 = true;
    public float speed = 5f;
    public float turnSpeed = 5f;
    public Transform point1;
    public Transform point2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToPoint1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(point1.position.x, point1.position.y), step);

            LookAt(point1.position);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(point2.position.x, point2.position.y), step);

            LookAt(point2.position);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.StartsWith("PatrolPoint"))
        {
            MoveToPoint1 = !MoveToPoint1;
        }

        if (col.name == "Player")
        {
            player.detectedByGuards.Add(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            player.detectedByGuards.Remove(gameObject);
        }
    }

    void LookAt(Vector3 pos)
    {
        Vector3 diff = pos - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
