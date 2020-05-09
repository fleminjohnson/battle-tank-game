using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        private static float DeathCount = 0;
        public EnemyController(EnemyView enemyView, EnemyModel enemyModel, EnemyColor enemyColor)
        {
            enemyView.ControllerChannelInitialisaton(this);
            EnemyView = enemyView;
            EnemyModel = enemyModel;
            EnemyView.ColorChange(enemyColor);
        }

        public EnemyView EnemyView { get; }
        public EnemyModel EnemyModel { get; private set; }

        //public void CollisionOccured()
        //{
        //    EnemyView.Death();
        //}

        public void Damage(int damage, Vector3 position)
        {
            if(EnemyModel.Health - damage < 0)
            {
                EnemyView.Death();
                DeathCount += 1;
                EventServices.GenericInstance.InvokeEnemyDeath();
                if (DeathCount == 10)
                {
                    EventServices.GenericInstance.InvokeOnTenEnemyKills();
                    DeathCount = 0;
                }
                EnemyService.Instance.EnemyDestroyed(position);
            }
            EnemyModel.DecrementHealth(damage) ;
        }

        public void RespawnRequest()
        {
            throw new NotImplementedException();
        }

        public void ShootEventInit()
        {
            EnemyService.Instance.BulletRequest(EnemyView.enemyTurretPosition, BulletVariants.STRONG);
        }
    }
}
