using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletService : SingletonBehaviour<BulletService>
    {
        public BulletView bulletView;
        public BulletScriptableObject[] bulletScriptableObject;
        private BulletModel bulletModel = null;
        public BulletController CreateBullet(Transform transform, BulletVariants bulletVariants, ID iD)
        {
            for (int i = 0; i < bulletScriptableObject.Length; i++)
            {
                if (bulletScriptableObject[i].bulletVariants == bulletVariants)
                {
                    bulletModel = new BulletModel(bulletScriptableObject[i], transform, iD);
                }
            }
            BulletController bulletController = new BulletController(bulletModel, bulletView);
            return bulletController;
        }
    }
}
