using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyView enemyView, EnemyModel enemyModel, EnemyColor enemyColor)
        {
            enemyView.ControllerChannelInitialisaton(this);
            EnemyView = enemyView;
            EnemyModel = enemyModel;
            EnemyView.ColorChange(enemyColor);
        }

        public EnemyView EnemyView { get; }
        public EnemyModel EnemyModel { get; private set; }

        public void CollisionOccured()
        {
            EnemyView.Death();
        }

        public void Damage(int damage)
        {
            if(EnemyModel.Health - damage < 0)
            {
                EnemyView.Death();
            }
            EnemyModel.DecrementHealth(damage) ;
        }

        public void ShootEventInit()
        {
            EnemyService.Instance.BulletRequest(EnemyView.enemyTurretPosition, BulletVariants.STRONG);
        }
    }
}
