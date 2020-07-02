using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Enemy.State;
using Player;

namespace Enemy
{
    public class EnemyView : MonoBehaviour,IDamagable
    {
        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingingState;
        public EnemyPatrollingState initialState;
        public EnemyAttackState attackState;
        public Material[] materialName;
        public Transform enemyTurretPosition;

        private EnemyController enemyController;
        private EnemyState currentState;
        private Rigidbody rb;
        private bool reloaded = false;
        private Transform target1;
        private Transform target2;
        private float angle = 0;
        private bool firstTime = true;
        private bool spanningOver = false;

        [SerializeField]
        private Transform HealthBarContainer;
        private Transform HealthBar;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            target1 = EnemyService.Instance.spawnTransform1;
            target2 = EnemyService.Instance.spawnTransform2;

            HealthBar = HealthBarContainer.transform.GetChild(0);
        }
        private void Start()
        {
            ChangeState(patrollingState);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                EnemyFire();
            }
        }

        public void ControllerChannelInitialisaton(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void Death()
        {
            gameObject.SetActive(false);
        }

        public void Respawn()
        {
            print("Player respawned");
            gameObject.SetActive(true);
            transform.localScale = transform.localScale * 0.75f;
            HealthBar.localPosition = Vector3.zero;
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
            enemyController.Damage(damage, transform.position);
        }

        public ID ReturnID()
        {
            return enemyController.EnemyModel.ID;   
        }

        public void RandomSpawning()
        {
            Vector3 pos = transform.position;
            float xPos;
            xPos = UnityEngine.Random.Range(-15f, 15f);
            transform.position = new Vector3(xPos, pos.y, pos.z);
        }

        public void EnemyPatrolling()
        {
            if (firstTime)
            {
                spanningOver = EnemyRotation(this.transform, target1);
                if (spanningOver)
                {
                    firstTime = !EnemyTranslation(this.transform, target1);
                }
            }
            else
            {
                if (!reloaded)
                {
                    spanningOver = EnemyRotation(this.transform, target2);
                    if (spanningOver)
                    {
                        reloaded = EnemyTranslation(this.transform, target2);
                    }
                }
                else
                {
                    spanningOver = EnemyRotation(this.transform, target1);
                    if (spanningOver)
                    {
                        reloaded = !EnemyTranslation(this.transform, target1);
                    }
                }
            }
        }

        public void EnemyStop()
        {
            rb.velocity = new Vector3(0,0,0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }

        public bool EnemyRotation(Transform origin, Transform destination)
        {
            Vector3 targetDirection = new Vector3(destination.position.x, 0.0f, destination.position.z) - origin.position;

            // The step size is equal to speed times frame time.
            float singleStep = 1 * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(origin.transform.forward, targetDirection, 
                                                          singleStep * enemyController.EnemyModel.Torque, 0.0f);
            float angle = Vector3.Angle(origin.transform.forward, newDirection);
            this.angle = angle;
            // Calculate a rotation a step closer to the target and applies rotation to this object
            origin.rotation = Quaternion.LookRotation(newDirection);

            if(angle == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnemyTranslation(Transform origin, Transform destination)
        {
            origin.transform.position = Vector3.MoveTowards(origin.position,destination.position, enemyController.EnemyModel.Force * Time.deltaTime);
            if (Vector3.Distance(origin.position, destination.position) < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnemyFire()
        {
            enemyController.ShootEventInit();
        }

        public void EnemyHealthBarUpdate(float percentage)
        {
            HealthBar.localPosition = HealthBar.localPosition + Vector3.left * percentage;
        }
    }
}
