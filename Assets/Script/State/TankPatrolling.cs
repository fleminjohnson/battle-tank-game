using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.State;

public class TankPatrolling : TankState
{
    private float timeElapsed;
    public override void OnEnterState()
    {
        base.OnEnterState();
        tankView.ColorSelector(tankColor);
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 5f)
        {
            tankView.ChangeState(tankView.chasingingState);
        }
    }
}
