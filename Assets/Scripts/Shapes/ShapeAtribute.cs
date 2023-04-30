public struct ShapeAtribute
{
    public ShapeType ShapeType { get; private set; }
    public ColorType ShapeColor { get; private set; }
    public int ShapeNum { get; private set; }

    public int IDShape;

    public Vector2Map PosOnGreed { get; private set; }

    public ShapeAtribute(ShapeType shapeType, ColorType colorType, int shapeNum, Vector2Map posOnGreed, int idShape)
    {
        ShapeType = shapeType;
        ShapeColor = colorType;
        ShapeNum = shapeNum;
        IDShape = idShape;
        PosOnGreed = posOnGreed;
    }
}