

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TankService : SingletonBehaviour<TankService>

{

    public TankView tankViewPrefab;
    public BulletService bulletService;
    

    void Update()

    {
        StartGame();
    }



    private void StartGame()

    {
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            CreateNewObject(TankColor.RED);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            CreateNewObject(TankColor.GREEN);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            CreateNewObject(TankColor.BLUE);
        }
    }

    public void BulletRequest(Transform turretPosition)
    {
        bulletService.CreateBullet(turretPosition);
    }

    private void CreateNewObject(TankColor color)

    {
        TankModel tankModel = new TankModel(4, 5, 2);
        tankViewPrefab.ColorSelector(color);
        TankController tankController = new TankController(tankModel, tankViewPrefab);
        tankController.TankServiceChannelInitiaize(this);
    }
    

}