using System;

namespace Pokimon
{
    public struct Vector2i
    {
        public int X;
        public int Y;

        public static Vector2i Zero { get { return new Vector2i(0, 0); } }
        public static Vector2i One { get { return new Vector2i(1, 1); } }
        public int Length => (int)Math.Sqrt(X * X + Y * Y); //Trovato su OpenTK (guardando ho visto lambda e quindi si verdà col Chirone)
        public int LengthSquared => X * X + Y * Y;

        #region Operators
        public static Vector2i operator + (Vector2i a, Vector2i b)
        {
            a.X += b.X;
            a.Y += b.Y;
            return a;
        }

        public static Vector2i operator - (Vector2i a, Vector2i b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }

        public static Vector2i operator * (Vector2i a, Vector2i b)
        {
            a.X *= b.X;
            a.Y *= b.Y;
            return a;
        }

        public static Vector2i operator *(Vector2i a, int b)
        {
            a.Y *= b;
            a.X *= b;
            return a;
        }

        public static Vector2i operator / (Vector2i a, Vector2i b)
        {
            a.X /= b.X;
            a.Y /= b.Y;
            return a;
        }

        public static Vector2i operator / (Vector2i a, int b)
        {
            a.X /= b;
            a.Y /= b;
            return a;
        }

        public static bool operator == (Vector2i a, Vector2i b)
        {
            if(a.X == b.X)
            {
                return a.Y == b.Y;
            }

            return false;
        }

        public static bool operator != (Vector2i a, Vector2i b)
        {
            if (a.X != b.X)
            {
                return a.Y != b.Y;
            }

            return false;
        }
        #endregion

        public Vector2i(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void Normalize()
        {
            int num = 1 / Length;
            X *= num;
            Y *= num;
        }

        public static Vector2i Lerp(Vector2i a, Vector2i b, float blend)
        {
            a.X = (int)(blend * (b.X - a.X) + a.X);
            a.Y = (int)(blend * (b.Y - a.Y) + a.Y);
            return a;
        }

        public static float Dot(Vector2i left, Vector2i right)
        {
            return left.X * right.X + left.Y * right.Y;
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector2i)
            {
                return false;
            }

            return Equals((Vector2i)obj);
        }

        public bool Equals(Vector2i other)
        {
            if (X == other.X)
            {
                return Y == other.Y;
            }

            return false;
        }

        public override int GetHashCode() // Copiato tantissimo da OpenTK
        {
            return (X.GetHashCode() * 397) ^ Y.GetHashCode();
        }
    }
}
