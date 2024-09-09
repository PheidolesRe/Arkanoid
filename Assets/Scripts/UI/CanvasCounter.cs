using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCounter : MonoBehaviour
{
    [SerializeField] private float timeToTurnOff = 3;

    private void Start()
    {
        TurnOffObject();
    }

    private void TurnOffObject()
    {
        StartCoroutine(TurnOffRoutine());
    }

    private IEnumerator TurnOffRoutine()
    {

        yield return new WaitForSeconds(timeToTurnOff);

        EventBus.OnGameStrated?.Invoke();
        gameObject.SetActive(false);
    }
}
