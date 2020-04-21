using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public MeshRenderer[] mesh;
    public Material tankMaterialRed;
    public Material tankMaterialGreen;
    public Material tankMaterialBlue;
    private Rigidbody rb;
    public TankController tankController;
    [SerializeField]
    private Transform turretPosition;
    private Vector3 position;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public Vector3 Position {get {return position;}}

    private void Update()
    {
        position = turretPosition.transform.position;
        tankController.MovementDirector();
    }
    public void ColorSelector(TankColor color)
    {
        for (int index = 0; index < 4; index++)
        {
            switch (color)
            {
                case TankColor.BLUE:
                    mesh[index].material = tankMaterialBlue;
                    break;
                case TankColor.GREEN:
                    mesh[index].material = tankMaterialGreen;
                    break;
                case TankColor.RED:
                    mesh[index].material = tankMaterialRed;
                    break;
            }
        }
    }

    public void RandomSpawning()
    {
        Vector3 pos = transform.position;
        float xPos;
        xPos = UnityEngine.Random.Range(-15f, 15f);
        transform.position = new Vector3(xPos, pos.y, pos.z);
    }

    public void Movement(TankDirection tankDirection, float speed)
    {
        switch (tankDirection)
        {
            case TankDirection.FRONT:
                Forward(speed);
                break;
            case TankDirection.BACK:
                BackWard(speed);
                break;
            case TankDirection.LEFT:
                Left(speed);
                break;
            case TankDirection.RIGHT:
                Right(speed);
                break;
        }
    }

    public void Initialize(TankController controller)
    {
        tankController = controller;
    }
 
    private void Right(float speed)
    {
        rb.velocity = Vector3.right * speed;
    }

    private void Left(float speed)
    {
        rb.velocity = Vector3.left * speed;
    }

    private void BackWard(float speed)
    {
        rb.velocity = Vector3.back * speed;
    }

    private void Forward(float speed)
    {
        rb.velocity = Vector3.forward * speed;
    }
}
