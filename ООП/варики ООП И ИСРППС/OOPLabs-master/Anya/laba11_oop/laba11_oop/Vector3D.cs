using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace laba11_oop
{
    class Vector3D
    {
        private int x;
        private int y;
        private int z;

        public Vector3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public int X
        {
            private set
            {
                this.x = value;
            }
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            set
            {
                this.y = value;
            }
            get
            {
                return this.y;
            }
        }

        public int Z
        {
            private set
            {
                this.z = value;
            }
            get
            {
                return this.z;
            }
        }

        public static double Length(Vector3D v)
        {
            double result = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);

            return result;
        }

        public static bool LengthEqw(Vector3D v1, Vector3D v2)
        {
            return Length(v1) == Length(v2); 
        }



        public static int ScalarProduct(Vector3D v1, Vector3D v2)
        {
            int result = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            return result;
        }


        public static double Angle(Vector3D v1, Vector3D v2)
        {
            double result = ScalarProduct(v1, v2) / (Length(v1) * Length(v2));

            return result;
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            Vector3D result = new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

            return result;
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            Vector3D result = new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

            return result;
        }

        public static Vector3D operator *(Vector3D v1, Vector3D v2)
        {
            int x, y, z;

            x = v1.Y * v2.Z - v1.Z * v2.Y;
            y = -(v1.X * v2.Z - v2.X * v1.Z);
            z = v1.X * v2.Y - v1.Y * v2.X;

            Vector3D result = new Vector3D(x, y, z);
            return result;
        }

        public static Vector3D operator *(Vector3D v, int value)
        {
            int x, y, z;

            x = v.X * value;
            y = v.Y * value;
            z = v.Z * value;

            Vector3D result = new Vector3D(x, y, z);
            return result;
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }
    }

    
}
