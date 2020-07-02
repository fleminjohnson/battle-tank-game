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
        //print("Entering chasing State");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        //print("Exiting chasing State");
    }
}
