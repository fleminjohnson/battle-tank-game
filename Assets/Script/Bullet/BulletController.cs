using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletView)
        {
            BulletModel = bulletModel;
            BulletView = bulletView;

            BulletView = GameObject.Instantiate<BulletView>(bulletView);
            BulletView.Initialize(this);
            BulletView.transform.position = BulletModel.Position.position;
            BulletView.transform.rotation = BulletModel.Position.rotation;
        }

        public void ControllerInitialization()
        {
            BulletView.Fire(BulletModel.BulletSpeed, BulletModel.Position);
        }
        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}
