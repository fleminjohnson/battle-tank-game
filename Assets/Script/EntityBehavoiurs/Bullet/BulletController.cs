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
            BulletView.transform.position = BulletModel.Transform.position;
            BulletView.transform.rotation = BulletModel.Transform.rotation;
        }

        public void FireCommand()
        {
            BulletView.Fire(BulletModel.BulletSpeed, BulletModel.Transform);
        }
        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}
