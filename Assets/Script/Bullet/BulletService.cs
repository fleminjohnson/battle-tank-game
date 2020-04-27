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
        public BulletController CreateBullet(Transform position, BulletVariants bulletVariants)
        {
            BulletModel bulletModel = new BulletModel(bulletScriptableObject[0], position);
            switch (bulletVariants)
            {
                case BulletVariants.WEAK:
                    bulletModel = new BulletModel(bulletScriptableObject[0], position);
                    break;
                case BulletVariants.MEDIUM:
                    bulletModel = new BulletModel(bulletScriptableObject[1], position);
                    break;
                case BulletVariants.STRONG:
                    bulletModel = new BulletModel(bulletScriptableObject[2], position);
                    break;
            }
            BulletController bulletController = new BulletController(bulletModel, bulletView);
            return bulletController;
        }
    }

}
