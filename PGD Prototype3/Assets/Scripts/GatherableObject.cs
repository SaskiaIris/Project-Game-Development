using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableObject : MonoBehaviour
{
    [SerializeField]
    private float health;

    public int ResourceAmount;
    
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
            Destroy(this.gameObject);
    }
}
