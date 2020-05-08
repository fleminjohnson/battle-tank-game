﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Particles;
using Enemy;
using Enemy.State;

namespace Player
{
    public class TankService : SingletonBehaviour<TankService>

    {

        public TankView tankViewPrefab;
        public BulletService bulletService;
        public TankScriptableObject[] tankConfigurations;


        void Start()

        {
            StartGame();
        }



        public void StartGame()

        {
            PlayerInstantiate(tankConfigurations[2]);
        }

        public void BulletRequest(Transform turretPosition, BulletVariants bulletVariants)
        {
            bulletService.CreateBullet(turretPosition, bulletVariants, ID.PLAYER);
        }

        private void PlayerInstantiate(TankScriptableObject tankScriptableObject)

        {
            TankView tankView;
            TankModel tankModel = new TankModel(tankScriptableObject.health,
                                                tankScriptableObject.force,
                                                tankScriptableObject.torque, 
                                                tankScriptableObject.bulletVariants, ID.PLAYER);

            tankView = GameObject.Instantiate<TankView>(tankViewPrefab);

            EnemyState.player = tankView;

            tankView.ColorSelector(tankScriptableObject.tankColor);
            TankController tankController = new TankController(tankModel, tankView);
        }

        public void TankDestroyed(Vector3 position)
        {
            ParticleServices.Instance.InitializeSmoke(position);      
        }
    }
}