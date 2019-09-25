using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public GameObject chosenRoute;
    public float speed = 5f;
    int followPointIndex = 0;
    float originalY;

    bool finished = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        originalY = transform.position.y;

        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        speed = slider.value;
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
                anim.SetBool("isWalking", false); 
            }

        }
    }
}
