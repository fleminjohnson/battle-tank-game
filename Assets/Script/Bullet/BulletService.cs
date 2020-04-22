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
    public void CreateBullet(Vector3 position)
    {
        BulletModel bulletModel = new BulletModel(5000.0f, position);
        BulletController bulletController = new BulletController(bulletModel, bulletView);
    }

}
