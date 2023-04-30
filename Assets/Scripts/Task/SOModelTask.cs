using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOModelTask", menuName = "SO/SOModelTask", order = 0)]
public class SOModelTask : ScriptableObject
{
    public List<TaskShapeView> ShapesList;
}
