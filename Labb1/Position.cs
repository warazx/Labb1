using System;

namespace Labb1
{
    public class Position
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value >= 0 ? value : 0; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value >= 0 ? value : 0; }
        }
        
        public double Length()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position p)
        {
            return (p.X == x) && (p.Y == y);
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public Position Clone()
        {
            return new Position(X,Y);
        }

        public static bool operator >(Position p1, Position p2)
        {
            if(p1.Length() == p2.Length())
                return (p1.X > p2.X);
            else
                return (p1.Length() > p2.Length());
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
                return (p1.X < p2.X);
            else
                return (p1.Length() < p2.Length());
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }
    }
}
