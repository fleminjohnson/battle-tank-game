
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TankController

{
    public TankController(TankModel tankModel, TankView tankView)

    {
        Debug.Log("New Object created", tankView);
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankView);
        tankView.RandomSpawning();
    }
    public static void MovementDirector(TankDirection tankDirection)
    {
        switch (tankDirection)
        {
            case TankDirection.FRONT:
                TankView.Movement(TankDirection.FRONT);
                break;
            case TankDirection.BACK:
                TankView.Movement(TankDirection.BACK);
                break;
            case TankDirection.LEFT:
                TankView.Movement(TankDirection.LEFT);
                break;
            case TankDirection.RIGHT:
                TankView.Movement(TankDirection.RIGHT);
                break;
        }
    }



    public TankModel TankModel { get; }

    public TankView TankView { get; }

}