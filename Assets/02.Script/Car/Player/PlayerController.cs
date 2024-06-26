using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private CarMoveSystem _carMoveSystem;

    private void Start()
    {
        _carMoveSystem = GetComponent<CarMoveSystem>();
    }

    private void FixedUpdate()
    {
        MoveInputSystem();
    }

    void MoveInputSystem()
    {
        float motorTorque = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        bool b_break = Input.GetKey(KeyCode.Space);

        _carMoveSystem.MoveWheel(motorTorque, steering, b_break);
    }
}
