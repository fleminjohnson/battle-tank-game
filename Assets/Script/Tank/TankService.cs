

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TankService : SingletonBehaviour<TankService>

{

    public TankView tankView;
    public BulletService bulletService;

    void Update()

    {
        StartGame();
        print(Input.GetAxis("Vertical"));
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



    private void CreateNewObject(TankColor color)

    {
        TankModel tankModel = new TankModel(4, 5);
        tankView.ColorSelector(color);
        TankController tankController = new TankController(tankModel, tankView);
        tankController.TankServiceChannelInitiaize(this);
    }
    public void BulletRequest(Vector3 position)
    {
        bulletService.CreateBullet(position);
    }

}