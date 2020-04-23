using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TankController
{
    TankService tankService;
    public TankController(TankModel tankModel, TankView tankView)

    {
        Debug.Log("New Object created", tankView);
        TankModel = tankModel;
        TankView = tankView;
        TankView.Initialize(this);
        TankView.RandomSpawning();
    }
    public void MovementDirector()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            tankService.BulletRequest(TankView.TurretPosition, BulletVariants.WEAK);
        }
        TankView.RotationAndTranslation(TankModel.Force,TankModel.Torque);
    }

    public void TankServiceChannelInitiaize(TankService ts)
    {
        tankService = ts;
    }

    public TankModel TankModel { get; }

    public TankView TankView { get; }

}