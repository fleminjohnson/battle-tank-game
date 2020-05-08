using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.State;

public class TankChasing : TankState
{
    [SerializeField]
    private TankColor anotherVariant;
    public override void OnEnterState()
    {
        base.OnEnterState();
        tankView.ColorSelector(anotherVariant);
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
}
