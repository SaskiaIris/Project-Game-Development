using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traps/SnakeTrap")]
public class SnakeTrap : ScareTrap
{
    public override void TriggerTrap()
    {
        base.TriggerTrap();

        particleSystem.Play();
    }
}
