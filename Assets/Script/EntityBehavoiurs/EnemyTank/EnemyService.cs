using Bullet;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Particles;

namespace Enemy
{
    public class EnemyService : SingletonBehaviour<EnemyService>, IServices
    {
        public EnemyView enemyViewPrefab;
        public Transform spawnTransform1;
        public Transform spawnTransform2;
        public EnemyScriptableObject enemyScriptableObject;
        private EnemyPooling enemyPooling;

        void Start()
        {
            enemyPooling = GetComponent<EnemyPooling>();

            for(int i = 0; i < 5; i++) 
            {
                CreateEnemy(enemyScriptableObject);
            }
        }

        private EnemyController CreateEnemy(EnemyScriptableObject enemyConfig)
        {
            EnemyModel enemyModel = new EnemyModel(enemyConfig.health,
                                                    enemyConfig.force,
                                                    enemyConfig.torque,
                                                    enemyConfig.bulletVariants,
                                                    enemyConfig.enemyColor,ID.ENEMY);
            //EnemyController enemyController = new EnemyController(enemyViewInstance, enemyModel, enemyConfig.enemyColor);
            EnemyController enemyController = enemyPooling.GetEnemy(enemyViewPrefab, enemyModel);
            return enemyController;
        }

        private void RespawnEnemy(EnemyScriptableObject enemyConfig)
        {
            EnemyController enemyController = CreateEnemy(enemyConfig);
            enemyController.EnemyView.Respawn();
            enemyController.EnemyModel.ResetHealth();
        }

        public void EnemyDestroyed(Vector3 position, EnemyController enemyController)
        {
            ParticleServices.Instance.InitializeSmoke(position,this);
            enemyPooling.ReturnItem(enemyController);
        }

        public void BulletRequest(Transform turretPosition, BulletVariants bulletVariants)
        {
            BulletService.Instance.CreateBullet(turretPosition, bulletVariants, ID.ENEMY);
        }

        public void RespawnRequest()
        {
            print("Player respawn request made");
            RespawnEnemy(enemyScriptableObject);
        }
    }
}

