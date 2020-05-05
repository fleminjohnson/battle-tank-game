using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyService : SingletonBehaviour<EnemyService>
    {
        public EnemyView enemyViewPrefab;
        private EnemyScriptableObject enemyConfig;
        public EnemyListScriptableObject enemyList;

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
    }
}

