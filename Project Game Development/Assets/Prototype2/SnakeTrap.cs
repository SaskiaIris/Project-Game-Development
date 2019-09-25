using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traps/SnakeTrap")]
public class SnakeTrap : ScareTrap
{
    //private ScareMeter scareMeter

    public override void Initialize(Vector3 position, GameObject target)
    {
        base.Initialize(position, target);
        //scareMeter = target.GetComponent<ScareMeter>();
    }

    public override void TriggerTrap()
    {
        //scaremeter.Scare(AmountOfScare);
    }
}
