using Core.Controller.Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesControllers : IExecute
{
    private ShapesViews _shapesViews;
    private MapView _map;
    private char _startChar = 'A';

    public ShapesControllers(ShapesViews shapesViews, MapView map)
    {
        _shapesViews = shapesViews;
        _map = map;
        SetPosOnGreed();
        SetAtributs();
    }

    public void Execute()
    {
    }

    private void SetPosOnGreed()
    {
        if (_shapesViews.ShapesList.Count>0 && _map.Cell.Count > 0)
        {
            foreach (var shap in _shapesViews.ShapesList)
            {
                float x = (_map.StartRealPos.x - shap.gameObject.transform.position.x + (_map.StepRealPos.x / 2));
                float tempXf = x / _map.StepRealPos.x;
                int tempXi = 1 + (int)tempXf;
                shap.PosOnGreed.x = tempXi;

                float y = _map.StartRealPos.y - shap.gameObject.transform.position.z + (_map.StepRealPos.y / 2);
                float tempYf = y / _map.StepRealPos.y;
                int tempYi = _startChar + (int)tempYf;
                char tempYch = (char)tempYi;
                shap.PosOnGreed.y = tempYch;
            }
        }
    }
    private void SetAtributs()
    {
        if (_shapesViews.ShapesList.Count > 0 && _map.Cell.Count > 0)
        {
            int id = 0;
            foreach (var shap in _shapesViews.ShapesList)
            {
                shap.IDShape= id++;
                shap.OnShapeChanged += SelectShape;
            }
            ClearOutLine();
        }
    }
    private void SelectShape(ShapeAtribute shapeAtribute, GameObject gameObject, int id)
    {
        ClearOutLine();
        _shapesViews.ShapeSelectID = id;
        _shapesViews.ShapesList[id].IsSelect= true;
        _shapesViews.ShapesList[id].outline.OutlineWidth = 1;
    }
    private void ClearOutLine()
    {
        foreach (var shap in _shapesViews.ShapesList)
        {
            shap.IsSelect = false;
            shap.outline.OutlineWidth = 0;
        }
    }
}