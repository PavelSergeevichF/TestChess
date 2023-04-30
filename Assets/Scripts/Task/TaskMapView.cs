using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMapView : MapBase
{
    [SerializeField] private List<TaskShapeView> _shapesList;
    [SerializeField] private SOModelTask _sOModelTask;
    

    public List<TaskShapeView> ShapesList => _shapesList;
    public SOModelTask SOModelTask => _sOModelTask;
    
}
