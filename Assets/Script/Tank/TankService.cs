

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
            CreateNewObject(TankColor.RED, 25, 10f, 2f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            CreateNewObject(TankColor.GREEN, 100, 20f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            CreateNewObject(TankColor.BLUE, 50, 20f, 1f);
        }
    }

    public void BulletRequest(Transform turretPosition, BulletVariants bulletVariants)
    {
        bulletService.CreateBullet(turretPosition, bulletVariants);
    }

    private void CreateNewObject(TankColor color, int health, float force,float torque)

    {
        TankView tankView;
        TankModel tankModel = new TankModel(health, force, torque);
        tankView = GameObject.Instantiate<TankView>(tankViewPrefab);
        tankView.ColorSelector(color);
        TankController tankController = new TankController(tankModel, tankView);
        tankController.TankServiceChannelInitiaize(this);
    }
    

}