namespace Dinghy.Core;

public class Grid
{
    public Point Pivot { get; }
    public List<Point> Points { get; }
    List<Point> OriginalPoints;
    private float rotation = 0f;
    public float Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = OriginalPoints[i].Transform(rotation, scaleX, scaleY, Pivot);
            }
        }
    }
    
    private float scaleX = 1f;
    public float ScaleX
    {
        get => scaleX;
        set
        {
            scaleX = value;
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = OriginalPoints[i].Transform(rotation, scaleX, scaleY, Pivot);
            }
        }
    }
    
    private float scaleY = 1f;
    public float ScaleY
    {
        get => scaleY;
        set
        {
            scaleY = value;
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = OriginalPoints[i].Transform(rotation, scaleY, scaleY, Pivot);
            }
        }
    }
    
    //start is world space point, pivot is what start is meant to be interpreted as in normal space relative to to whole grid
    public Grid(Point pivot, Point normalizedPivotPos, int cellWidth, int cellHeight, Point normalizedCellOffset, int xcount, int ycount)
    {
        Points = new List<Point>();
        var x_max = xcount * cellWidth;
        var y_max = ycount * cellHeight;

        Point cellOffset = (normalizedCellOffset.X * cellWidth, normalizedCellOffset.Y * cellHeight);
        Point gridStart = pivot - (
            x_max * normalizedPivotPos.X,
            y_max * normalizedPivotPos.Y
        ) + cellOffset;
        Pivot = pivot + cellOffset;
        for (int y = 0; y < ycount; y++)
        {
            for (int x = 0; x < xcount; x++)
            {
                Points.Add((
                        gridStart.X + (x * cellWidth),
                        gridStart.Y + (y * cellHeight)
                ) + cellOffset);
            }
        }

        OriginalPoints = new List<Point>(Points);
    }

    public void ApplyPositionsToEntites<T>(List<T> entities) where T : Entity
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (i < Points.Count)
            {
                entities[i].SetPosition((int)Points[i].X,(int)Points[i].Y,entities[i].Rotation,entities[i].ScaleX,entities[i].ScaleY);
            }
        }
    }
}