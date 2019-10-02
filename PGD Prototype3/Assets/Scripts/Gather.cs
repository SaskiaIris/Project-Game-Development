using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gather : MonoBehaviour
{
    //start position for the raycast that detects
    //a valid target in front of the player
    [SerializeField]
    private GameObject raycastStart;

    //objects in the gatherable layer
    [SerializeField]
    private LayerMask gatherableLayerMask;

    [SerializeField]
    private float gatherCooldown = 1f, gatherAmount = 10f, gatherRange = 2f, gatherMultiplier = 1f, gatherDamage = 25f;

    [SerializeField]
    private Text resourceText;
    
    //amount of resources the player has
    private float resource;
    private bool isGathering = false;

    //objects that's hit by raycast to detect a target
    private Transform target;
    private Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        GetInput();
        //update UI text
        resourceText.text = "Resource amount: " + resource.ToString();
    }

    private void GetInput()
    {
        //check for left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            if (CanGather())
                StartCoroutine(GatherResources());
        }
    }
    
    private IEnumerator GatherResources()
    {
        isGathering = true;
        //wait before giving the resources
        yield return new WaitForSeconds(gatherCooldown);

        if(target == null)
        {
            Debug.LogError("Gathering, but no target found");
            yield return null;
        }
        //get gather script from target
        GatherableObject gatherTarget = target.GetComponent<GatherableObject>();
        //add resources
        resource += gatherTarget.ResourceAmount * gatherMultiplier;
        //deal damage to target object
        gatherTarget.TakeDamage(gatherDamage);
        //end coroutine
        isGathering = false;
        yield return null;
    }

    private bool CanGather()
    {
        return !isGathering && InRange();
    }

    private bool InRange()
    {
        //check if there is a gatherable object in front of the player
        if (Physics.Raycast(raycastStart.transform.position, raycastStart.transform.forward, out RaycastHit hit, gatherRange, gatherableLayerMask))
        {
            target = hit.transform;
            return true;
        }
        return false;
    }
}
