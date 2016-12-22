using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public bool Equals(Position p)
        {
            return (p.X == X) && (p.Y == Y);
        }

        public Position Clone()
        {
            return new Position { X = x, Y = y };
        }

        public static bool operator >(Position p1, Position p2)
        {
            if(p1.Length() == p2.Length())
            {
                return (p1.X > p2.X);
            }
            else
            {
                return (p1.Length() > p2.Length());
            }
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return (p1.X < p2.X);
            }
            else
            {
                return (p1.Length() < p2.Length());
            }
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position { X = (p1.X + p2.X), Y = (p1.Y + p2.Y)};
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position { X = (p1.X - p2.X), Y = (p1.Y - p2.Y) };
        }

        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}
