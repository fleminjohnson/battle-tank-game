using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particles;

namespace Player
{
    public class TankController
    {
        private float bulletCount = 0;
        public TankController(TankModel tankModel, TankView tankView)

        {
            TankModel = tankModel;
            TankView = tankView;
            BulletVariants = tankModel.BulletVariants;
            TankView.Initialize(this);
            TankView.RandomSpawning();
        }
        public void MovementDirector()
        {
            TankView.RotationAndTranslation(TankModel.Force,TankModel.Torque);
        }

        public void ShootEventInit()
        {
            TankService.Instance.BulletRequest(TankView.enemyTurretPosition, BulletVariants);
            bulletCount += 1;
            if(bulletCount == 100)
            {
                EventServices.GenericInstance.InvokeOnHundredBulletsFired();
                bulletCount = 0;
            }
        }

        public TankModel TankModel { get; }

        public TankView TankView { get; }
        public BulletVariants BulletVariants { get; }

        public void EnemyHit(Vector3 position, int damage)
        {
            if (TankModel.Health - damage < 0)
            {
                TankView.DestroyTank();
                TankService.Instance.TankDestroyed(position);
            }
            TankModel.DecrementHealth(damage);
        }
    }
}
