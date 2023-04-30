using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeView : ShapeBase
{
    public bool IsSelect=false;
    public delegate void SentDataShape(ShapeAtribute shapeAtribute, GameObject gameObject, int id);
    public event SentDataShape OnShapeChanged;
    public Outline outline;

    private void OnMouseDown()
    {
        ShapeAtribute shapeAtribute = new ShapeAtribute(ShapeType, ShapeColor, ShapeNum, PosOnGreed, IDShape);
        OnShapeChanged?.Invoke(shapeAtribute, this.gameObject, IDShape);
    }
}