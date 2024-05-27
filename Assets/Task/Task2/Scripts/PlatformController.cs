using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    public float maxSpeed = 2f;
    public float acceleration = 1f;
    private float targetSpeed;
    private float currentSpeed;

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
        targetSpeed = maxSpeed;
        motor.motorSpeed = currentSpeed;
        sliderJoint.motor = motor;
    }

    private void Update()
    {
        if (ReachedEndPoint())
        {
            targetSpeed = -targetSpeed;
        }

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        motor.motorSpeed = currentSpeed;
        sliderJoint.motor = motor;
    }

    private bool ReachedEndPoint()
    {
        return (sliderJoint.limitState == JointLimitState2D.UpperLimit && targetSpeed > 0) ||
               (sliderJoint.limitState == JointLimitState2D.LowerLimit && targetSpeed < 0);
    }
}
