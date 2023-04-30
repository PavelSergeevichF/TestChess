using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBase : MonoBehaviour
{
    [SerializeField] private ShapeType _shapeType;
    [SerializeField] private ColorType _shapeColor;
    [SerializeField] private int _shapeNum;

    public ShapeType ShapeType => _shapeType;
    public ColorType ShapeColor => _shapeColor;
    public int ShapeNum => _shapeNum;
    public int IDShape;

    public Vector2Map PosOnGreed;
}
