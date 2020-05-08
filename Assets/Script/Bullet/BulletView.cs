using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletcontroller;
        Rigidbody rb;
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Start()
        {
            bulletcontroller.ControllerInitialization();
            //Fire(5.0f);
        }

        public void Fire(float speed, Transform position)
        {
            rb.AddForce(position.forward * speed, ForceMode.Impulse);
        }

        public void Initialize(BulletController bulletControl)
        {
            bulletcontroller = bulletControl;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.GetComponent<TankView>() == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
