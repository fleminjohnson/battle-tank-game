
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



    public TankModel TankModel { get; }

    public TankView TankView { get; }

}