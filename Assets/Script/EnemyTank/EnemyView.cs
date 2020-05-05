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
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
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

        public void EnemyRotationAndTranslation()
        {
            StartCoroutine(EnemyTranslation());
            StartCoroutine(EnemyRotation());
        }

        public void EnemyStop()
        {
            rb.velocity = new Vector3(0,0,0);
            rb.angularVelocity = new Vector3(0,0,0);
        }

        private IEnumerator EnemyTranslation()
        {
            rb.velocity = transform.forward * enemyController.EnemyModel.Force;
            yield return new WaitForSeconds(1.0f);
        }
        private IEnumerator EnemyRotation()
        {
            yield return EnemyTranslation();
            rb.angularVelocity = Vector3.up * enemyController.EnemyModel.Torque;
            yield return new WaitForSeconds(1.0f);
            EnemyStop();
        }
    }
}
