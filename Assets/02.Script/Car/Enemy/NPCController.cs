using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private CarMoveSystem _carMoveSystem;
    private CarInfo _carInfo;
    public Vector3 TargetPos;
    public Vector3 TeamAIPos;
    public int CheckWayRange;
    public int CheckCharacterRange;

    private void Start()
    {
        TargetPos = GameManager.Instance.Player().transform.position;
        _carMoveSystem = GetComponent<CarMoveSystem>();
        _carInfo = GetComponent<CarInfo>();
    }

    private void FixedUpdate()
    {
         MoveInput();
    }

    public void MoveInput()
    {
        Vector3 targetDistance = transform.InverseTransformPoint(TargetPos);
        targetDistance = targetDistance.normalized;

        if (Vector3.Distance(TargetPos, transform.position) <= CheckWayRange) _carMoveSystem.MoveWheel(1, targetDistance.x);
        else if (Vector3.Distance(TeamAIPos, transform.position) <= CheckCharacterRange) _carMoveSystem.MoveWheel(1, TeamAIPos.x * -2);
        else _carMoveSystem.MoveWheel(1, _carInfo.TargetPoint.position.x);
    }
}
