using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{   
    private CarMoveSystem _carMoveSystem;
    private CarInfo _carInfo;
    private void Start()
    {
        _carMoveSystem = GetComponent<CarMoveSystem>();
        _carInfo = GetComponent<CarInfo>();

    }

    private void FixedUpdate()
    {
        MoveAI();
    }

    public void MoveAI()
    {
        Vector3 wayPointDistance = transform.InverseTransformPoint(_carInfo.TargetPoint.position);
        wayPointDistance = wayPointDistance.normalized;
        _carMoveSystem.MoveWheel(1, wayPointDistance.x, false);
    }
}
