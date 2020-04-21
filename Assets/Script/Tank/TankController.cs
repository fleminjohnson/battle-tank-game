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
        TankView = GameObject.Instantiate<TankView>(tankView);
        TankView.Initialize(this);
        TankView.RandomSpawning();
    }
    public void MovementDirector()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TankView.Movement(TankDirection.FRONT, TankModel.Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TankView.Movement(TankDirection.BACK, TankModel.Speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TankView.Movement(TankDirection.RIGHT, TankModel.Speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TankView.Movement(TankDirection.LEFT, TankModel.Speed);
        }

        if (Input.GetKey(KeyCode.F))
        {
            tankService.BulletRequest(TankView.Position) ;
        }
    }

    public void TankServiceChannelInitiaize(TankService ts)
    {
        tankService = ts;
    }

    public TankModel TankModel { get; }

    public TankView TankView { get; }

}