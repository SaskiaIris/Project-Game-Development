using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : ScriptableObject
{
    public string Name = "New trap";
    public string Description = "It's a trap";
    public Sprite Icon;

    public bool IsActivatable;

    protected GameObject target;
    protected Vector3 position;

    protected ParticleSystem particleSystem;

    public virtual void Initialize(Vector3 position, GameObject target)
    {
        this.position = position; this.target = target;
    }

    public void SetParticleSystem(ParticleSystem particleSystem)
    {
        this.particleSystem = particleSystem;
    }

    public virtual void CheckForTarget() { }

    public abstract void TriggerTrap();
}
