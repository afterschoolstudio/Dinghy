namespace Dinghy.Core;

public class Grid
{
    private Point pivot;
    public Point Pivot
    {
        get => pivot;
        set
        {
            pivot = value;
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = OriginalPoints[i].Transform(rotation, scaleX, scaleY, Pivot);
            }
        }
    }
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

    public class GridCreationParams
    {
        public Point Pivot;
        public Point NormalizedPivotPos;
        public Point NormalizedCellOffset;
        public int CellWidth;
        public int CellHeight;
        public int Xcount;
        public int Ycount;
        public GridCreationParams(Point pivot,
            Point normalizedPivotPos,
            int cellWidth,
            int cellHeight,
            Point normalizedCellOffset,
            int xcount,
            int ycount)
        {
            Pivot = pivot;
            NormalizedPivotPos = normalizedPivotPos;
            NormalizedCellOffset = normalizedCellOffset;
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            Xcount = xcount;
            Ycount = ycount;
        }
    }
    
    //start is world space point, pivot is what start is meant to be interpreted as in normal space relative to to whole grid
    public Grid(GridCreationParams p)
    {
        Points = new List<Point>();
        var x_max = p.Xcount * p.CellWidth;
        var y_max = p.Ycount * p.CellHeight;

        Point cellOffset = (p.NormalizedCellOffset.X * p.CellWidth, p.NormalizedCellOffset.Y * p.CellHeight);
        Point gridStart = p.Pivot - (
            x_max * p.NormalizedPivotPos.X,
            y_max * p.NormalizedPivotPos.Y
        ) + cellOffset;
        this.pivot = p.Pivot + cellOffset;
        for (int y = 0; y < p.Ycount; y++)
        {
            for (int x = 0; x < p.Xcount; x++)
            {
                Points.Add((
                        gridStart.X + (x * p.CellWidth),
                        gridStart.Y + (y * p.CellHeight)
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