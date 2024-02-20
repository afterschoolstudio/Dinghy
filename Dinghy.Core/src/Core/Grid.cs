using System.Numerics;
namespace Dinghy.Core;

public class Grid
{
    private Vector2 pivot;
    public Vector2 Pivot
    {
        get => pivot;
        set
        {
            pivot = value;
            pushPointUpdates();
        }
    }
    public List<Vector2> Points { get; }
    List<Vector2> OriginalPoints;
    private float rotation = 0f;
    public float Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            pushPointUpdates();
        }
    }
    
    private float scaleX = 1f;
    public float ScaleX
    {
        get => scaleX;
        set
        {
            scaleX = value;
            pushPointUpdates();
        }
    }
    
    private float scaleY = 1f;
    public float ScaleY
    {
        get => scaleY;
        set
        {
            scaleY = value;
            pushPointUpdates();
        }
    }

    public void SetAndApplyGridTransforms(float rotation, float scaleX, float scaleY)
    {
        this.rotation = rotation;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        pushPointUpdates();
    }

    void pushPointUpdates()
    {
        for (int i = 0; i < Points.Count; i++)
        {
            Points[i] = OriginalPoints[i].Transform(rotation, scaleX, scaleY, pivot);
        }
    }

    public class GridCreationParams
    {
        public Vector2 Pivot;
        public Vector2 NormalizedPivotPos;
        public Vector2 NormalizedCellOffset;
        public int CellWidth;
        public int CellHeight;
        public int Xcount;
        public int Ycount;
        public GridCreationParams(Vector2 pivot,
            Vector2 normalizedPivotPos,
            int cellWidth,
            int cellHeight,
            Vector2 normalizedCellOffset,
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
        Points = new List<Vector2>();
        OriginalPoints = new List<Vector2>();
        var x_max = p.Xcount * (p.CellWidth * p.NormalizedCellOffset.X);
        var y_max = p.Ycount * (p.CellHeight * p.NormalizedCellOffset.Y);

        Vector2 cellOffset = new(p.NormalizedCellOffset.X * p.CellWidth, p.NormalizedCellOffset.Y * p.CellHeight);

        pivot = p.Pivot;
        Vector2 gridStart = pivot - new Vector2(
            x_max * p.NormalizedPivotPos.X,
            y_max * p.NormalizedPivotPos.Y
        );
        for (int y = 0; y < p.Ycount; y++)
        {
            for (int x = 0; x < p.Xcount; x++)
            {
                OriginalPoints.Add(new Vector2(
                        gridStart.X + (x * p.CellWidth),
                        gridStart.Y + (y * p.CellHeight)
                ) - cellOffset);
            }
        }

        Points = new List<Vector2>(OriginalPoints);
    }
    
    

    public void ApplyPositionsToEntites<T>(List<T> entities) where T : Entity
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (i < Points.Count)
            {
                entities[i].SetPosition((int)Points[i].X,(int)Points[i].Y,entities[i].Rotation,entities[i].ScaleX,entities[i].ScaleY,entities[i].PivotX,entities[i].PivotY);
            }
        }
    }

    public void ApplyPositionToEntity<T>(int i, T entity) where T : Entity
    {
        if (i >= Points.Count)
        {
            Console.WriteLine("grid index out of bounds");
            return;
        }
        entity.SetPosition((int)Points[i].X,(int)Points[i].Y,entity.Rotation,entity.ScaleX,entity.ScaleY,entity.PivotX,entity.PivotY);
    }
}