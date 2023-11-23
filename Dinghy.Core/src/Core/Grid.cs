namespace Dinghy.Core;

public class Grid
{
    public List<Point> Points;
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
                Points[i] = OriginalPoints[i].Transform(rotation, 1, 1, Pivot);
            }
        }
    }
    
    public Point Pivot { get; set; }
    
    public Grid(Point start, Point pivot, int cellWidth, int cellHeight, int xcount, int ycount)
    {
        Points = new List<Point>();
        Pivot = start + pivot;
        for (int y = 0; y < ycount; y++)
        {
            for (int x = 0; x < xcount; x++)
            {
                Points.Add((start.X - pivot.X + x * cellWidth,start.Y - pivot.Y + y * cellHeight));
            }
        }

        OriginalPoints = new List<Point>(Points);
    }
}