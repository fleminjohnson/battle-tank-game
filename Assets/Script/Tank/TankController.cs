using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TankController
    {
        TankService tankService;
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
            tankService.BulletRequest(TankView.TurretPosition, BulletVariants);
        }

        public void TankServiceChannelInitiaize(TankService ts)
        {
            tankService = ts;
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
