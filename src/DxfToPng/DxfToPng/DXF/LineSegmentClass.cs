using System;
using System.Drawing;


public class LineSegmentClass
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    public LineSegmentClass()
    {
    }

    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    public LineSegmentClass(PointF p1, PointF p2)
    {
        _point1 = p1;
        _point2 = p2;
    }

    private PointF _point1 = new PointF(0, 0);
    private PointF _point2 = new PointF(0, 0);
    private float _length = 0.0F;

    /// <summary>
    /// 
    /// </summary>
    public PointF Point1
    {
        get { return this._point1; }
        set { this._point1 = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public PointF Point2
    {
        get { return this._point2; }
        set { this._point2 = value; }
    }

    /// <summary>
    /// Length of line segment
    /// </summary>
    /// <returns></returns>
    public float Length()
    {
        _length = (float)Math.Sqrt(Math.Pow((_point2.X - _point1.X), 2) + Math.Pow((_point2.Y - _point1.Y), 2));
        return this._length;
    }

}
