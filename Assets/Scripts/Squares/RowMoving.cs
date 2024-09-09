using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMoving : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.OnMovedRow += MoveRows;
    }

    private void OnDisable()
    {
        EventBus.OnMovedRow -= MoveRows;        
    }

    public void MoveRows()
    {
        transform.position = transform.position - new Vector3(0, 1.5f, 0);  
    }
}
