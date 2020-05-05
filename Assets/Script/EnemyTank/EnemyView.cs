using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Enemy.State;

namespace Enemy
{
    public class EnemyView : MonoBehaviour,IDamagable
    {
        private EnemyController enemyController;
        private EnemyState currentState;
        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingingState;
        public EnemyPatrollingState initialState;
        public Material[] materialName;

        private void Start()
        {
            ChangeState(patrollingState);
        }

        public void ControllerChannelInitialisaton(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        public void ColorChange(EnemyColor tankColor)
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
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material = material;
            }
        }


        public void ChangeState(EnemyState nextState)
        {
            if (currentState != null)
            {
                currentState.EnemyExitingState();
            }
            currentState = nextState;
            currentState.EnemyEnteringState();
        }

        public void GetDamage(int damage)
        {
            enemyController.Damage(damage);
        }

        public ID ReturnID()
        {
            return enemyController.EnemyModel.ID;   
        }
    }
}
