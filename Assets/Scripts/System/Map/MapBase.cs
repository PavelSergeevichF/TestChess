using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBase : MonoBehaviour
{
    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private Vector2 _startRealPos;
    [SerializeField] private Vector2 _stepRealPos;

    public Vector2Int MapSize => _mapSize;
    public Vector2 StartRealPos => _startRealPos;
    public Vector2 StepRealPos => _stepRealPos;
}
