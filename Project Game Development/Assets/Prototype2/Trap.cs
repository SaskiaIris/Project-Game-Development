using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : ScriptableObject
{
    public string Name = "New trap";
    public string Description = "It's a trap";
    public Sprite Icon;
    
    protected GameObject target;
    protected Vector3 position;
    
    public virtual void Initialize(Vector3 position, GameObject target)
    {
        position = this.position;  target = this.target;
    }

    public virtual void CheckForTarget() { }

    public abstract void TriggerTrap();
}
