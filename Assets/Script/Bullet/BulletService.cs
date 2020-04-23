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
    public BulletController CreateBullet(Transform position)
    {
        BulletModel bulletModel = new BulletModel(5f, position);
        BulletController bulletController = new BulletController(bulletModel, bulletView);
        return bulletController;
    }
}
