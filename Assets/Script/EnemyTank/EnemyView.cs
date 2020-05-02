using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Enemy.State;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
        private EnemyState currentState;

        public EnemyPatrollingState patrollingState;

        public EnemyChasingState chasingingState;

        private EnemyPatrollingState initialState;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<BulletView>() != null)
            {
                enemyController.CollisionOccured();
            }
        }

        public void ControllerChannelInitialisaton(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }

        public void ColorChange(EnemyColor enemyColorInstance)
        {
            EnemyService.Instance.ApplyMaterial(enemyColorInstance,this);
        }

        public void ChangeState(EnemyState nextState)
        {
            if(currentState != null)
            {
                currentState.EnemyExitingState();
            }
            currentState = nextState;
            currentState.EnemyEnteringState();
        }
    }

}
