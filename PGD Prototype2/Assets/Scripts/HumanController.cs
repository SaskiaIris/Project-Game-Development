using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public GameObject chosenRoute;
    public float speed = 5f;
    int followPointIndex = 0;
    float originalY;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(chosenRoute.transform.childCount);
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, chosenRoute.transform.GetChild(followPointIndex).position, step);

        transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Point")
        {
            if (followPointIndex + 1 < chosenRoute.transform.childCount)
            {
                followPointIndex++;
            }

        }
    }
}
