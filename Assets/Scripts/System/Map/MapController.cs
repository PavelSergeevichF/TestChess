using Core.Controller.Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : IExecute
{
    private MapView _map;
    private char _startChar = 'A';

    public MapController(MapView map)
    {
        _map = map;
        SetAtributs();
    }

    public void Execute()
    {
    }

    private void SetAtributs()
    {
        if (_map.Cell.Count > 0)
        {
            int id = 0;
            foreach (var cell in _map.Cell)
            {
                cell.IDCell= id++;

                float x = (_map.StartRealPos.x - cell.gameObject.transform.position.x + (_map.StepRealPos.x / 2));
                float tempXf = x / _map.StepRealPos.x;
                int tempXi = 1 + (int)tempXf;
                cell.PosOnGreed.x = tempXi;

                float y = _map.StartRealPos.y - cell.gameObject.transform.position.z + (_map.StepRealPos.y / 2);
                float tempYf = y / _map.StepRealPos.y;
                int tempYi = _startChar + (int)tempYf;
                char tempYch = (char)tempYi;
                cell.PosOnGreed.y = tempYch;

                cell.OnCell += SelectCell;

                ClearOutLine();
            }
        }
    }
    private void SelectCell(Vector2Map posOnGreed, int id)
    {
        ClearOutLine();
        _map.Cell[id].IsSelect = true;
    }

    private void ClearOutLine()
    {
        foreach (var cell in _map.Cell)
        {
            cell.IsSelect = false;
            cell.outline.OutlineWidth = 0;
        }
    }
}
