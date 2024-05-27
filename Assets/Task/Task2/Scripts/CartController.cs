using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public WheelJoint2D wheelJoint1;
    public WheelJoint2D wheelJoint2;
    public float motorSpeed = 1000f;

    private JointMotor2D motor;
    private bool playerOnCart = false;

    void Start()
    {
        motor = new JointMotor2D { motorSpeed = motorSpeed, maxMotorTorque = 10000f };
    }

    void Update()
    {
        if (playerOnCart)
        {
            wheelJoint1.useMotor = true;
            wheelJoint2.useMotor = true;
            wheelJoint1.motor = motor;
            wheelJoint2.motor = motor;
        }
        else
        {
            wheelJoint1.useMotor = false;
            wheelJoint2.useMotor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnCart = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnCart = false;
        }
    }
}
