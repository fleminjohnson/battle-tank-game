using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankView)

        {
            //Debug.Log("New Object created", tankView);
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
            TankService.Instance.BulletRequest(TankView.TurretPosition, BulletVariants);
        }

        public TankModel TankModel { get; }

        public TankView TankView { get; }
        public BulletVariants BulletVariants { get; }

        public void EnemyHit()
        {
            TankView.DestroyGameObject();
        }
    }
}
