using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : SingletonBehaviour<BulletService>
{
    public BulletView bulletView;
    // Start is called before the first frame update

    public void Start()
    {
        //CreateBullet();
    }
    public BulletController CreateBullet(Transform position, BulletVariants bulletVariants)
    {
        BulletModel bulletModel = new BulletModel(5f, position, 10);
        switch (bulletVariants)
        {
            case BulletVariants.WEAK:
                bulletModel = new BulletModel(5f, position, 10);
                break;
            case BulletVariants.MEDIUM:
                bulletModel = new BulletModel(5f, position, 20);
                break;
            case BulletVariants.STRONG:
                bulletModel = new BulletModel(5f, position, 30);
                break;
        }
        BulletController bulletController = new BulletController(bulletModel, bulletView);
        return bulletController;
    }
}
