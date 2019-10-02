using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableObject : MonoBehaviour
{
    [SerializeField]
    private float health;

    public int ResourceAmount { get; private set; }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
