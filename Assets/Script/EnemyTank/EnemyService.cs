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
        public Material[] materialName;

        private void Update()
        {
            StartGame();
        }

        private void StartGame()
        {
            enemyConfig = enemyList.enemy[UnityEngine.Random.Range(0, enemyList.enemy.Length)];
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
                                                  enemyConfig.enemyColor);
            ApplyMaterial(enemyConfig.enemyColor, enemyViewInstance);
            EnemyController enemyController = new EnemyController(enemyViewInstance, enemyModel);
        }

        private void ApplyMaterial(EnemyColor tankColor, EnemyView enemyView)
        {
            Material material = null;
            switch (tankColor)
            {
                case EnemyColor.GOLDEN:
                    material = materialName[0];
                    break;
                case EnemyColor.SILVER:
                    material = materialName[1];
                    break;
                case EnemyColor.YELLOW:
                    material = materialName[2];
                    break;
            }
            for (int i = 0; i < enemyView.transform.GetChild(0).childCount; i++)
            {
                enemyView.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material = material;
            }
        }
    }
}

