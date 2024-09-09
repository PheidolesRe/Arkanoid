using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSquares : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private float spaceBetweenSquares = 1.2f;

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        Vector2 spawnPosition = new Vector2(-7, 0);


        for (int i = 0; i < 13; i++)
        {
            GameObject newSquares = Instantiate(squarePrefab);
            newSquares.transform.parent = transform;
            newSquares.transform.localPosition = new Vector2(spaceBetweenSquares * i - 7, 0);
        }
    }
}
