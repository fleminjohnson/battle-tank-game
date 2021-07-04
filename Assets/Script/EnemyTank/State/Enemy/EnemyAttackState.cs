using Enemy.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float timeLapsed = 0;
    private bool spanningOver = false;
    public override void EnemyEnteringState()
    {
        base.EnemyEnteringState();
        print("Attack Mode activated");
    }

    public override void EnemyExitingState()
    {
        base.EnemyExitingState();
        print("Attack Mode Deactivated");
    }

    private void Update()
    {
        timeLapsed += Time.deltaTime;
        if(timeLapsed > 0.25 & spanningOver)
        {
            enemyView.EnemyFire();
            timeLapsed = 0;
        }
        if(player != null)
        {
            spanningOver = enemyView.EnemyRotation(this.transform, player.transform);
        }
    }
}
