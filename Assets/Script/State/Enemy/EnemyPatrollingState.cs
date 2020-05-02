using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyPatrollingState : EnemyState
    {
        private float timeElapsed;
        public override void EnemyEnteringState()
        {
            base.EnemyEnteringState();
            print("Enemy Entering patrolling state");
            enemyView.ColorChange(EnemyColor.SILVER);
        }

        public override void EnemyExitingState()
        {
            base.EnemyExitingState();
            print("Enemy Exiting patrolling state");
        }

        private void Update()
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed > 5f)
            {
                enemyView.ChangeState(enemyView.chasingingState);
            }
        }
    }
}
