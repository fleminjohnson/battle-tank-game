

using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class TankService : SingletonBehaviour<TankService>

{

    public TankView tankView;

    void Start()

    {

        StartGame();

    }



    private void StartGame()

    {

        for (int i = 0; i < 5; i++)

        {

            CreateNewObject();

        }

    }



    private void CreateNewObject()

    {

        TankModel tankModel = new TankModel(4, 600);

        TankController tankController = new TankController(tankModel, tankView);

    }

}