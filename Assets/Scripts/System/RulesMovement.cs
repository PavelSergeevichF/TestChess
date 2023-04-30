using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesMovement 
{
    public bool HorseCheck(Vector2Map posOnGreedShape, Vector2Map posOnGreedCell)
    {
        bool result = false;
        if (
            (posOnGreedShape.x + 2 == posOnGreedCell.x && posOnGreedShape.y + 1 == posOnGreedCell.y) ||
            (posOnGreedShape.x + 2 == posOnGreedCell.x && posOnGreedShape.y - 1 == posOnGreedCell.y) ||
            (posOnGreedShape.x - 2 == posOnGreedCell.x && posOnGreedShape.y + 1 == posOnGreedCell.y) ||
            (posOnGreedShape.x - 2 == posOnGreedCell.x && posOnGreedShape.y - 1 == posOnGreedCell.y) ||
            (posOnGreedShape.x + 1 == posOnGreedCell.x && posOnGreedShape.y + 2 == posOnGreedCell.y) ||
            (posOnGreedShape.x + 1 == posOnGreedCell.x && posOnGreedShape.y - 2 == posOnGreedCell.y) ||
            (posOnGreedShape.x - 1 == posOnGreedCell.x && posOnGreedShape.y + 2 == posOnGreedCell.y) ||
            (posOnGreedShape.x - 1 == posOnGreedCell.x && posOnGreedShape.y - 2 == posOnGreedCell.y)
            ) 
        { 
            result = true;
        }
        return result;
    }

}
