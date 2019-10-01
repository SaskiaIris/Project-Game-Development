using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitboxHandler : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public string filter;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == filter)
        {
            gameObjects.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == filter)
        {
            RemoveFromList(collider.gameObject);
        }
    }

    public void RemoveFromList(GameObject goRemove)
    {
        foreach(GameObject go in gameObjects)
        {
            if (go.GetInstanceID() == goRemove.GetInstanceID())
            {
                gameObjects.Remove(go);
                return;
            }
        }
    }
}
