using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private CarMoveSystem _carMoveSystem;

    // Start is called before the first frame update
    void Start()
    {
        _carMoveSystem = GetComponent<CarMoveSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
