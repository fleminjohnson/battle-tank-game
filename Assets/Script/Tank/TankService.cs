﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Particles;


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
            CreateNewObject(tankConfigurations[2]);
        }

        public void BulletRequest(Transform turretPosition, BulletVariants bulletVariants)
        {
            bulletService.CreateBullet(turretPosition, bulletVariants);
        }

        private void CreateNewObject(TankScriptableObject tankScriptableObject)

        {
            TankView tankView;
            TankModel tankModel = new TankModel(tankScriptableObject.health,
                                               tankScriptableObject.force,
                                     tankScriptableObject.torque, tankScriptableObject.bulletVariants);

            tankView = GameObject.Instantiate<TankView>(tankViewPrefab);
            tankView.ColorSelector(tankScriptableObject.tankColor);
            TankController tankController = new TankController(tankModel, tankView);
        }

        public void TankDestroyed(Vector3 position)
        {
            ParticleServices.Instance.InitializeSmoke(position);      
        }
    }
}