using Core.Controller.Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : IExecute
{
    private bool _isMoveShape = false;
    private int _selectShapeId;
    private Vector2Map _targetPosOnGreed;
    private float _speedMove=1f;
    private float _fallibility = 0.02f;

    private TaskMapView _taskMapView;
    private MapView _map;
    private ShapesViews _shapesViews;
    private RulesMovement _rulesMovement;

    public delegate void SentVictory();
    public event SentVictory FinishLevel;

    public MainController(TaskMapView taskMapView, MapView map, ShapesViews shapesViews)
    {
        _taskMapView = taskMapView;
        _map = map;
        _shapesViews = shapesViews;
        _rulesMovement = new RulesMovement();
        _targetPosOnGreed.x = 0;
        _targetPosOnGreed.y = 'A';
        SetAtributs();
    }

    public void Execute()
    {
        if (_isMoveShape) MoveShape();
    }
    private void SetAtributs()
    {
        if (_map.Cell.Count > 0)
        {
            foreach (var cell in _map.Cell)
            {
                cell.OnCell += GetCell;
            }
        }
        if (_shapesViews.ShapesList.Count > 0 && _map.Cell.Count > 0)
        {
            foreach (var shap in _shapesViews.ShapesList)
            {
                shap.OnShapeChanged += SelectShape;
            }
        }
    }
    private void SelectShape(ShapeAtribute shapeAtribute, GameObject gameObject, int id)
    {
        _selectShapeId = id;
    }
    private void GetCell(Vector2Map posOnGreed, int id)
    {
        if (_rulesMovement.HorseCheck(_shapesViews.ShapesList[_shapesViews.ShapeSelectID].PosOnGreed, posOnGreed))
        {
            _map.Cell[id].outline.OutlineWidth = 0.5f;
            _map.Cell[id].outline.OutlineColor = Color.green;
            _isMoveShape = true;
            _targetPosOnGreed = posOnGreed;
        }

    }
    private void MoveShape()
    {
        _shapesViews.ShapesList[_shapesViews.ShapeSelectID].transform.position =
            Vector3.MoveTowards(_shapesViews.ShapesList[_shapesViews.ShapeSelectID].transform.position, GetRealPos(_targetPosOnGreed), Time.deltaTime * _speedMove);
        if(CheckFinish(_shapesViews.ShapesList[_shapesViews.ShapeSelectID].transform.position, GetRealPos(_targetPosOnGreed)))
        {
            _isMoveShape=false;
            _shapesViews.ShapesList[_shapesViews.ShapeSelectID].PosOnGreed = _targetPosOnGreed;
            if (CheckTaskComplite(_shapesViews.ShapesList[_shapesViews.ShapeSelectID].PosOnGreed, _taskMapView.ShapesList[0].PosOnGreed))
            {
                FinishTask();
            }
        }
    }
    private Vector3 GetRealPos(Vector2Map posOnGreed)
    {
        Vector3 realPos= Vector3.zero;
        foreach(var cell in _map.Cell)
        { 
            if(cell.PosOnGreed.x == posOnGreed.x && cell.PosOnGreed.y == posOnGreed.y)
            {
                realPos = cell.transform.position;
                break;
            }
        }
        return realPos;
    }
    private bool CheckFinish(Vector3 ShapePosOnGreed, Vector3 TargetPosOnGreed)
    {
        bool isFinish = false;
        isFinish = 
            (
            (ShapePosOnGreed.x> TargetPosOnGreed.x- _fallibility && ShapePosOnGreed.x < TargetPosOnGreed.x + _fallibility) &&
            (ShapePosOnGreed.z > TargetPosOnGreed.z - _fallibility && ShapePosOnGreed.z < TargetPosOnGreed.z  + _fallibility)
            );
        return isFinish;
    }
    private bool CheckTaskComplite(Vector2Map ShapePosOnGreed, Vector2Map TaskPosOnGreed) => (ShapePosOnGreed.x == TaskPosOnGreed.x) && (ShapePosOnGreed.y == TaskPosOnGreed.y);

    private void FinishTask()
    {
        FinishLevel?.Invoke();
    }
}
