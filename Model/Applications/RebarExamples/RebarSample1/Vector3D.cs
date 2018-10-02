using System;
using System.Collections;
using Tekla.Structures.Model;

namespace GeoTools
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>

    public class Vector3D
    {
        private double xx;
        private double yy;
        private double zz;
        static private double ZeroLength = 1e-9;
        
        public static implicit operator Point(Vector3D v)
        {
            Point temp = new Point(v.X, v.Y, v.Z);
            return temp;
        }
 

        public static implicit operator Vector3D(Point p)
        {
            Vector3D temp = new Vector3D(p.X, p.Y, p.Z);
            return temp;
        }
 
        public static implicit operator Vector(Vector3D v)
        {
            Vector temp = new Vector(v.X, v.Y, v.Z);
            return temp;
        }
 

        public static implicit operator Vector3D(Vector v)
        {
            Vector3D temp = new Vector3D(v.X, v.Y, v.Z);
            return temp;
        }

        public Vector3D(object o)
        {
            Point p = o as Point;
            Vector3D v = o as Vector3D;
            if(p != null)
            {
                xx = p.X;
                yy = p.Y;
                zz = p.Z;
            }
            else if(v != null)
            {
                xx = v.X;
                yy = v.Y;
                zz = v.Z;
            }
        }
 

        public Vector3D()
        {
            xx = yy = zz = 0;
        }

        public Vector3D(double x, double y, double z)
        {
            xx = x;
            yy = y;
            zz = z;
        }

        public Vector3D(Vector3D v)
        {
            xx = v.X;
            yy = v.Y;
            zz = v.Z;
        }

        public Vector3D(Vector2D v)
        {
            xx = v.X;
            yy = v.Y;
            zz = 0;
        }

        public Vector3D SetXYZ(double x, double y, double z)
        {
            xx = x;
            yy = y;
            zz = z;
            return this;
        }

        public Vector3D Set(object o)
        {
            Vector3D v = o as Vector3D;
            Point p = o as Point;
            if(v != null)
            {
                xx = v.X;
                yy = v.Y;
                zz = v.Z;
            }
            if(p != null)
            {
                xx = p.X;
                yy = p.Y;
                zz = p.Z;
            }
            else
            {
            }
            return this;
        }

        public double X
        {
            get
            {
                return xx;
            }
            set
            {
                xx = value;
            }
        }

        public double Y
        {
            get
            {
                return yy;
            }
            set
            {
                yy = value;
            }
        }

        public double Z
        {
            get
            {
                return zz;
            }
            set
            {
                zz = value;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(xx*xx + yy*yy + zz*zz);
            }
            set
            {
                double CurrentLength = Length;
                if(Math.Abs(CurrentLength) > ZeroLength)
                {
                    xx = value * xx / CurrentLength;
                    yy = value * yy / CurrentLength;
                    zz = value * zz / CurrentLength;
                }
            }
        }

        public double Dot(Vector3D b)
        {
            return this.X * b.X + this.Y * b.Y + this.Z * b.Z;
        }

        public Vector3D Cross(Vector3D b)
        {
            Vector3D Result = new Vector3D(this.Y * b.Z - this.Z * b.Y,
                -this.X * b.Z + this.Z * b.X,
                this.X * b.Y - this.Y * b.X);
            return Result;
        }

        public static Vector3D operator +(Vector3D a, Vector3D b) 
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator -(Vector3D a, Vector3D b) 
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator *(Vector3D a, double b) 
        {
            return new Vector3D(b * a.X, b* a.Y, b * a.Z);
        }

        public static Vector3D operator *(double a, Vector3D b) 
        {
            return new Vector3D(a * b.X, a * b.Y, a * b.Z);
        }

        public override string ToString()
        {
            return(String.Format("({0} , {1}, {2})", xx, yy, zz));
        }

        public void Normalize()
        {
            Length = 1.0;
        }
    }
}
