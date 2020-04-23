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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public Transform TurretPosition { get; private set; }

    private void Update()
    {
        TurretPosition = turretPosition;
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

    public void SurfaceGliding(float speed)
    {
        Vector3 vertical   = transform.forward * Input.GetAxis("Vertical")   * speed;
        Vector3 horizontal = transform.right   * Input.GetAxis("Horizontal") * speed;
        rb.velocity = vertical + horizontal;
    }

    public void RotationAndTranslation(float speed, float sensitivity)
    {
        rb.velocity = transform.forward * Input.GetAxis("Vertical") * speed;
        rb.angularVelocity = Vector3.up * Input.GetAxis("Horizontal") * sensitivity;
        //new Vector3(0f, Input.GetAxis("Horizontal"), 0f)
    }

    public void Initialize(TankController controller)
    {
        tankController = controller;
    }
}
