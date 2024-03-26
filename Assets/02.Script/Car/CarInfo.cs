using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CarInfo : MonoBehaviour
{
    public Transform TargetPoint;
    public int TargetPointIndex = 0; 
    public int CheckRange;
    public bool bIsReverse ;
    public bool bIsFinishLine = false;

    private void Start()
    {
        FoundWay();

    }

    private void FixedUpdate()
    {
        FoundWay();
    }

    public void FoundWay()
    {        
        if(bIsReverse == false) TargetPoint = GameManager.Instance.WayPoints.GetChild(OutIndex(TargetPointIndex));
        else TargetPoint = GameManager.Instance.WayPoints.GetChild(OutIndex(TargetPointIndex - 1));

        if (Vector3.Distance(TargetPoint.position, transform.position) <= CheckRange)
        {
            if (bIsReverse == false) TargetPointIndex++;
            else TargetPointIndex--;

            if (TargetPointIndex == GameManager.Instance.WayPoints.childCount - 1) bIsFinishLine = true;

            TargetPointIndex = OutIndex(TargetPointIndex);
        }
    }

    public int OutIndex(int Input)
    {
       if (0 > Input) return GameManager.Instance.WayPoints.childCount + Input;
       if (GameManager.Instance.WayPoints.childCount <= Input) return Input %= GameManager.Instance.WayPoints.childCount;

       return Input;
    }
}
