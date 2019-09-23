using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public GameObject chosenRoute;
    public float speed = 5f;
    int followPointIndex = 0;
    float originalY;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(chosenRoute.transform.childCount);
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            float step = speed * Time.deltaTime;
            Transform currentChildFollowing = chosenRoute.transform.GetChild(followPointIndex);
            transform.position = Vector3.MoveTowards(transform.position, currentChildFollowing.position, step);

            // Freeze Y Position
            transform.position = new Vector3(transform.position.x, originalY, transform.position.z);

            Vector3 targetLookat = new Vector3(currentChildFollowing.position.x, transform.position.y, currentChildFollowing.position.z);
            transform.LookAt(targetLookat);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Point" && chosenRoute.transform.GetChild(followPointIndex) == coll.gameObject.transform)
        {
            if (followPointIndex + 1 < chosenRoute.transform.childCount)
            {
                followPointIndex++;
            }
            else
            {
                finished = true;
            }

        }
    }
}
