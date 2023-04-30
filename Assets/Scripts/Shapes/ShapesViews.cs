using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesViews : MonoBehaviour
{
    [SerializeField] private List<ShapeView> _shapesList;

    public List<ShapeView> ShapesList => _shapesList;
    public int ShapeSelectID;
}
