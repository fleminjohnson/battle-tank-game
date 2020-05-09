using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyChasingState : EnemyState
    {
        private bool functionOver = false;
        public override void EnemyEnteringState()
        {
            base.EnemyEnteringState();
            print("Enemy Entering Chasing State");
            enemyView.ColorChange(EnemyColor.GOLDEN);
        }

        private void Update()
        {
            if(player != null)
            {
                functionOver = enemyView.EnemyRotation(this.transform, player.transform);
                if (functionOver)
                {
                    enemyView.EnemyTranslation(this.transform, player.transform);
                }
            }
            if(Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                enemyView.ChangeState(enemyView.attackState);
            }
        }

        public override void EnemyExitingState()
        {
            base.EnemyExitingState();
            //print("Enemy Exiting Chasing State");
        }
    }
}
