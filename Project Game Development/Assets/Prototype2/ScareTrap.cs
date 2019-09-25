using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTrap : Trap
{
    [SerializeField]
    protected float AmountOfScare = 5f;
    [SerializeField]
    protected float TrapRange = 5f;

    public override void CheckForTarget()
    {
        if(InRange())
        {
            TriggerTrap();
        }
    }

    public override void TriggerTrap() { }

    protected bool InRange()
    {
        return Vector3.Distance(position, target.transform.position) <= TrapRange;
    }
}
