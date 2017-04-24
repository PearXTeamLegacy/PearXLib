using System.Drawing;

namespace PearXLib.Maths
{
    /// <summary>
    /// Utilities that can be associated with points, sizes and mathematics.
    /// </summary>
	public static class PointSizeUtils
	{
	    /// <summary>
	    /// Divide a point by a size.
	    /// </summary>
	    /// <param name="left">Divident.</param>
	    /// <param name="right">Divisor.</param>
	    /// <returns>Quotient.</returns>
	    public static PointF Divide(this Point left, SizeF right)
	    {
	        return new PointF(left.X / right.Width, left.Y / right.Height);
	    }

	    /// <summary>
	    /// Converts a Point to PointF.
	    /// </summary>
	    /// <param name="p">Target point.</param>
	    /// <returns>Returned point.</returns>
	    public static Point ToPoint(this PointF p)
	    {
	        return new Point((int)p.X, (int)p.Y);
	    }

	    /// <summary>
	    /// Converts a SizeF to Size.
	    /// </summary>
	    /// <param name="sz">Input size.</param>
	    public static Size ToSize(this SizeF sz)
	    {
	        return new Size((int)sz.Width, (int)sz.Height);
	    }

	    /// <summary>
	    /// Gets the nearest to "sz" size in power of "powerOf".
	    /// </summary>
	    /// <param name="sz">Input size.</param>
	    /// <param name="powerOf">Power of X</param>
	    public static Size NearestPowerOf(this Size sz, int powerOf)
	    {
	        return new Size(MathUtils.NearestPowerOf(sz.Width, powerOf), MathUtils.NearestPowerOf(sz.Height, powerOf));
	    }
	}
}
