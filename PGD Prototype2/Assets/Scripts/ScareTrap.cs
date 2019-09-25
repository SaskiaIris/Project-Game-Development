using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTrap : Trap
{
    [SerializeField]
    protected float AmountOfScare = 5f;
    [SerializeField]
    protected float TrapRange = 5f;

    private ScareMeter scareMeter;

    public override void Initialize(Vector3 position, GameObject target)
    {
        base.Initialize(position, target);
        scareMeter = FindObjectOfType<ScareMeter>();
    }

    public override void CheckForTarget()
    {
        if (InRange())
        {
            TriggerTrap();
        }
    }

    public override void TriggerTrap()
    {
        if(IsActivatable)
        {
            if(!InRange())
                return;
        }

        scareMeter.scare += Mathf.RoundToInt(AmountOfScare);
    }

    protected bool InRange()
    {
        return Vector3.Distance(position, target.transform.position) <= TrapRange;
    }
}
