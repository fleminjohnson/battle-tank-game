using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletController(BulletModel bulletModel, BulletView bulletView)
    {
        BulletModel = bulletModel;
        BulletView = bulletView;

        BulletView = GameObject.Instantiate<BulletView>(bulletView);
        BulletView.Initialize(this);
        BulletView.transform.position = BulletModel.Position;
    }

    public void ControllerInitialization()
    {
        BulletView.Fire(BulletModel.BulletSpeed);
    }
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }
}
