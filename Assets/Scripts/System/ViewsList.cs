using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsList : MonoBehaviour
{
    [SerializeField] private MapView _map;
    [SerializeField] private ShapesViews _shapesViews;
    [SerializeField] private TaskMapView _taskMapView;
    [SerializeField] private EffectView _effectView;

    public MapView Map => _map;
    public ShapesViews ShapesViews => _shapesViews;
    public TaskMapView TaskMapView => _taskMapView;
    public EffectView EffectView => _effectView;
}
