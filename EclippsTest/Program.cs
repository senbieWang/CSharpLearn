using System;

namespace EclippsTest
{
    public class Point2D
    {
        public Point2D(double _x,double _y)
        {
            X = _x;
            Y = _y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public static class GeometryMath
    {

        //https://blog.csdn.net/he_zhidan/article/details/81347426
        //求椭圆上点的坐标
        //a 椭圆长轴  b 椭圆短轴
        // radian  点与椭圆长轴夹角的弧度  
        //dChangZhouAngle  长轴弧度  （长轴与水平坐标的弧度）
        public static Point2D GetPointOnEllipse(Point2D ptCenter, double a, double b, double radian, double dChangZhouAngle)
        {
            double temp = b;
            if (a < b)
            {
                b = a;
                a = temp;
            }

            double dLiXin = Math.Atan2(a * Math.Sin(radian), b * Math.Cos(radian));
            double x = a * Math.Cos(dLiXin) * Math.Cos(dChangZhouAngle) - b * Math.Sin(dLiXin) * Math.Sin(dChangZhouAngle) + ptCenter.X;
            double y = a * Math.Cos(dLiXin) * Math.Sin(dChangZhouAngle) + b * Math.Sin(dLiXin) * Math.Cos(dChangZhouAngle) + ptCenter.Y;
            return new Point2D(x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point2D center = new Point2D(9837, 9316);
            double a = Math.Abs(9837 - 9843);
            double b = Math.Abs(9316- 9843);
            var xx = GeometryMath.GetPointOnEllipse(center, 2*a, 2*b, 4.2919622924309033, 1);
        }
    }
}
