using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class WheelInfo
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool Motor;
    public bool Steer;
}

public class CarMoveSystem : MonoBehaviour
{
    public WheelInfo[] WheelInfo;

    public float MaxMotor;
    public float MaxSteer;
    public float BrakeForce;

    public void MoveWheel(float motorTorque, float steer, bool bIsBrake = false)
    {
        foreach (var wheel in WheelInfo) 
        {
            if (wheel.Motor)
            {
                wheel.LeftWheel.motorTorque = MaxMotor * motorTorque;
                wheel.RightWheel.motorTorque = MaxMotor * motorTorque;
            }
            if (wheel.Steer)
            {
                wheel.LeftWheel.steerAngle = MaxSteer * steer;
                wheel.RightWheel.steerAngle = MaxSteer * steer;
            }

            float isBrake = bIsBrake ? 1 : 0;
            wheel.LeftWheel.brakeTorque = isBrake * BrakeForce;
            wheel.RightWheel.brakeTorque = isBrake * BrakeForce;

            WheelPos(wheel.LeftWheel);
            WheelPos(wheel.RightWheel);
        }
    }

    void WheelPos(WheelCollider wheel)
    {
        Transform tier = wheel.transform.GetChild(0);
        wheel.GetWorldPose(out Vector3 pos, out Quaternion rot);
        tier.position = pos;
        tier.rotation = rot;
    }
}