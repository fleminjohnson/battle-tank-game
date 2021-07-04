using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particles;

namespace Player
{
    public class TankController
    {
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
            TankModel.BulletCount += 1;
            if(TankModel.BulletCount%100 == 0)
            {
                EventServices.GenericInstance.InvokeOnHundredBulletsFired();
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
            TankView.HealthBarUpdate(TankModel.DecrementHealth(damage));
        }
    }
}
