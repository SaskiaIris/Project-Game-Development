using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp;
    HitboxHandler hitboxHandlerAttack;

    public List<GameObject> GetEnemiesInRange()
    {
        List<GameObject> newList = new List<GameObject>();
        List<GameObject> removeList = new List<GameObject>();

        foreach (GameObject enemy in hitboxHandlerAttack.gameObjects)
        {
            if (enemy != null)
                newList.Add(enemy);
            else
                removeList.Add(enemy);
        }

        // Cleanup
        foreach (GameObject o in removeList)
            hitboxHandlerAttack.RemoveFromList(o);


        return newList;
    }
    // Start is called before the first frame update
    void Start()
    {
        hitboxHandlerAttack = GameObject.Find("Hitbox_attack").GetComponent<HitboxHandler>();
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
