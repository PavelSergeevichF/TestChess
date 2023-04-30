using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellView : MonoBehaviour
{
    [SerializeField] private ColorType _cellColor;

    public int IDCell;
    public bool IsSelect = false;
    public delegate void SentDataCell(Vector2Map posOnGreed, int id);
    public event SentDataCell OnCell;
    public Outline outline;

    public ColorType CellColor => _cellColor;
    public bool IsFree = true;
    public bool IsCanSelect = false;

    public Vector2Map PosOnGreed;

    private void OnMouseDown()
    {
        OnCell?.Invoke(PosOnGreed, IDCell);
    }
}
