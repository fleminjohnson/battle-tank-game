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
            enemyView.EnemyPatrolling();
        }

        public override void EnemyExitingState()
        {
            base.EnemyExitingState();
            print("Enemy Exiting patrolling state");
            enemyView.EnemyStop();
        }

        private void Update()
        {
            float distance = 50;
            if (player != null)
            {
                distance = Vector3.Distance(player.transform.position, transform.position);
            }
            if (distance < 20)
            {
                enemyView.ChangeState(enemyView.chasingingState);
            }
        }
    }
}
