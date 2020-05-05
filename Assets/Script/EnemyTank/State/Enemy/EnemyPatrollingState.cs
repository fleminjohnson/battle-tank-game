using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

        private void FixedUpdate()
        {
            enemyView.EnemyRotationAndTranslation();
        }

        public override void EnemyExitingState()
        {
            base.EnemyExitingState();
            print("Enemy Exiting patrolling state");
            enemyView.EnemyStop();
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
