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
        private EnemyScriptableObject enemyConfig;
        public EnemyListScriptableObject enemyList;
        public Transform spawnTransform1;
        public Transform spawnTransform2;

        private void Update()
        {
            StartGame();
        }

        private void StartGame()
        {
            enemyConfig = enemyList.enemy[UnityEngine.Random.Range(0,enemyList.enemy.Length)];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreateEnemy();
            }
        }

        private void CreateEnemy()
        {
            EnemyView enemyViewInstance = GameObject.Instantiate<EnemyView>(enemyViewPrefab);
            EnemyModel enemyModel = new EnemyModel(enemyConfig.health,
                                                  enemyConfig.force,
                                                  enemyConfig.torque,
                                                  enemyConfig.bulletVariants,
                                                  enemyConfig.enemyColor, ID.ENEMY);
            EnemyController enemyController = new EnemyController(enemyViewInstance, enemyModel, enemyConfig.enemyColor);
        }

        public void EnemyDestroyed(Vector3 position)
        {
            ParticleServices.Instance.InitializeSmoke(position,this);
        }

        public void BulletRequest(Transform turretPosition, BulletVariants bulletVariants)
        {
            BulletService.Instance.CreateBullet(turretPosition, bulletVariants, ID.ENEMY);
        }

        public void RespawnRequest()
        {
            CreateEnemy();
        }
    }
}

