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
    public bool Steer;
    public bool Motor;
}

public class CarMoveSystem : MonoBehaviour
{
    public WheelInfo[] WheelInfo;

    public float MaxMotor;
    public float MaxSteer;
    public float BrakeForce;

    public void MoveWheel(float motorTorque, float steer, bool bIsBrake)
    {
        foreach(var wheel in WheelInfo)
        {
            if (wheel.Motor)
            {
                wheel.LeftWheel.motorTorque = MaxMotor * motorTorque;
                wheel.RightWheel.motorTorque = MaxMotor * motorTorque;
            }
            if(wheel.Steer)
            {
                wheel.LeftWheel.steerAngle = steer * MaxSteer;
                wheel.RightWheel.steerAngle = steer * MaxSteer; 
            }

            float isbrake = bIsBrake ? 1 : 0;
            wheel.LeftWheel.brakeTorque = BrakeForce * isbrake;
            wheel.RightWheel.brakeTorque = BrakeForce * isbrake;

            WheelPos(wheel.LeftWheel);
            WheelPos(wheel.RightWheel);
        }
    }

    void WheelPos(WheelCollider wheel)
    {
        Transform Tier = wheel.transform.GetChild(0);
        wheel.GetWorldPose(out Vector3 pos, out Quaternion rot);

        Tier.position = pos;
        Tier.rotation = rot;
    }
}