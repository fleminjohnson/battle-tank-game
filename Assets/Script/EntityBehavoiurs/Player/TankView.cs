﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Tank.State;


namespace Player
{
    public class TankView : MonoBehaviour,IDamagable
    {
        public MeshRenderer[] mesh;
        public Material tankMaterialRed;
        public Material tankMaterialGreen;
        public Material tankMaterialBlue;
        public TankController tankController;

        [SerializeField]
        private Transform turretPosition;
        [SerializeField]
        public TankPatrolling patrollingState;
        [SerializeField]
        public TankChasing chasingingState;
        [SerializeField]
        private TankState initialState;
        [SerializeField]
        private Transform HealthBarContainer;
        private Transform HealthBar;

        private Rigidbody rb;
        private Material selfMat;    
        private TankState currentState;
        private Transform CameraPos;
        [SerializeField]
        private Vector3 offset;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            selfMat = GetComponent<Material>();
            HealthBar = HealthBarContainer.transform.GetChild(0);
        }

        public Transform enemyTurretPosition { get; private set; }

        private void Start()
        {
            enemyTurretPosition = turretPosition;
            ChangeState(GetComponent<TankPatrolling>());
            CameraPos = Camera.main.transform;

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankController.ShootEventInit();
            }
            tankController.MovementDirector();
            CameraPos.position = new Vector3(transform.position.x + offset.x,
                                   CameraPos.position.y, transform.position.z + offset.z);
        }
        public void ColorSelector(TankColor color)
        {
            for (int index = 0; index < 4; index++)
            {
                switch (color)
                {
                    case TankColor.BLUE:
                        mesh[index].material = tankMaterialBlue;
                        break;
                    case TankColor.GREEN:
                        mesh[index].material = tankMaterialGreen;
                        break;
                    case TankColor.RED:
                        mesh[index].material = tankMaterialRed;
                        break;
                }
            }
        }

        public void DestroyTank()
        {
            Destroy(gameObject);
        }

        public void RandomSpawning()
        {
            Vector3 pos = transform.position;
            float xPos;
            xPos = UnityEngine.Random.Range(-15f, 15f);
            transform.position = new Vector3(xPos, pos.y, pos.z);
        }

        public void SurfaceGliding(float speed)
        {
            Vector3 vertical = transform.forward * Input.GetAxis("Vertical") * speed;
            Vector3 horizontal = transform.right * Input.GetAxis("Horizontal") * speed;
            rb.velocity = vertical + horizontal;
        }

        public void RotationAndTranslation(float speed, float sensitivity)
        {
            rb.velocity = transform.forward * Input.GetAxis("Vertical") * speed;
            rb.angularVelocity = Vector3.up * Input.GetAxis("Horizontal") * sensitivity;
            //rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed, ForceMode.VelocityChange);
            //rb.AddTorque(Vector3.up * Input.GetAxis("Horizontal") * sensitivity, ForceMode.VelocityChange);
        }

        public void Initialize(TankController controller)
        {
            tankController = controller;
        }

        private void OnCollisionEnter(Collision collision)
        {
            int damage = 5;
            if (collision.collider.GetComponent<EnemyView>())
            {
                tankController.EnemyHit(transform.position, damage);
            }
        }

        public void ChangeColor(Color color)
        {
            selfMat.color = color;       
        }
        public void ChangeState(TankState newTankState)
        {
            if (currentState != null)
            {
                currentState.OnExitState();
            }
            currentState = newTankState;
            currentState.OnEnterState();
        }

        public void GetDamage(int damage)
        {
            tankController.EnemyHit(transform.position, damage);
        }

        public ID ReturnID()
        {
            return tankController.TankModel.ID;   
        }

        public void HealthBarUpdate(float percentage)
        {
            HealthBar.localPosition = HealthBar.localPosition + Vector3.left * percentage;
            print(HealthBar.localPosition);
        }
    }
}

