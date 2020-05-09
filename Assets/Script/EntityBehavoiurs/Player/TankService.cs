using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Particles;
using Enemy;
using Enemy.State;

namespace Player
{
    public class TankService : SingletonBehaviour<TankService>, IServices

    {

        public TankView tankViewPrefab;
        public BulletService bulletService;
        public TankScriptableObject[] tankConfigurations;
        public int bulletCount = 0;

        private int playerCount = 0;
        private static int respawnCount = 0;


        void Start()

        {
            StartGame();
        }



        public void StartGame()

        {
            PlayerInstantiate(tankConfigurations[2]);
            playerCount += 1;
            print(playerCount);
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
            ParticleServices.Instance.InitializeSmoke(position, this);
            EventServices.GenericInstance.InvokeOnplayerDeath();
            playerCount -= 1;
            print(playerCount);
            bulletCount = TankModel.BulletCount;
        }

        public void RespawnRequest()
        {
            if(respawnCount < 4)
            {
                if (playerCount == 0)
                {
                    StartGame();
                }
            }
            else
            {
                EventServices.GenericInstance.InvokeOnGameOver(bulletCount);
            }
            EventServices.GenericInstance.InvokeOnRespawn();
            respawnCount += 1;
        }
    }
}