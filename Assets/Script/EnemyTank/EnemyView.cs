using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
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

        internal void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }

}
