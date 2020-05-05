using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyChasingState : EnemyState
    {
        public override void EnemyEnteringState()
        {
            base.EnemyEnteringState();
            print("Enemy Entering Chasing State");
            enemyView.ColorChange(EnemyColor.GOLDEN);
        }

        public override void EnemyExitingState()
        {
            base.EnemyExitingState();
            print("Enemy Exiting Chasing State");
        }
    }
}
