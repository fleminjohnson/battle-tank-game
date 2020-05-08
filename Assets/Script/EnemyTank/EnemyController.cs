using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyView enemyView, EnemyModel enemyModel)
        {
            enemyView.ControllerChannelInitialisaton(this);
            EnemyView = enemyView;
        }

        public EnemyView EnemyView { get; }

        public void CollisionOccured()
        {
            EnemyView.DestroyGameObject();
        }
    }
}
