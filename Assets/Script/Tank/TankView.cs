using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;


namespace Player
{
    public class TankView : MonoBehaviour
    {
        public MeshRenderer[] mesh;
        public Material tankMaterialRed;
        public Material tankMaterialGreen;
        public Material tankMaterialBlue;
        private Rigidbody rb;
        public TankController tankController;
        [SerializeField]
        private Transform turretPosition;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public Transform TurretPosition { get; private set; }

        private void Start()
        {
            TurretPosition = turretPosition;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tankController.ShootEventInit();
            }
            tankController.MovementDirector();
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
            if (collision.collider.GetComponent<EnemyView>())
            {
                tankController.EnemyHit(transform.position);
            }
        }
    }
}

