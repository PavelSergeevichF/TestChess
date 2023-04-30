using Core.Controller.Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MapBase
{
    [SerializeField] private List<CellView> _cell;

    public List<CellView> Cell => _cell;

}
