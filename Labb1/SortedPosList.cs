using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Labb1
{
    public class SortedPosList : IEnumerable<Position>
    {
        private List<Position> positions = new List<Position>();
        private string filePath { get; set; }

        public SortedPosList() { }

        public SortedPosList(string filePath)
        {
            this.filePath = filePath;
            Load(filePath);
        }

        public int Count()
        {
            return positions.Count();
        }

        public void Add(Position p)
        {
            positions.Add(p);
            SortList();
            if(filePath != null) Save();
        }

        public bool Remove(Position p)
        {
            int positionsRemoved = positions.RemoveAll(pos => pos.Equals(p));
            if(positionsRemoved > 0)
            {
                if(filePath != null) Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public SortedPosList Clone()
        {
            SortedPosList newList = new SortedPosList();
            foreach (Position p in positions)
            {
                newList.Add(p.Clone());
            }
            newList.SortList();
            return newList;
        }

        public SortedPosList CircleContent(Position centerPosition, double radius)
        {
            SortedPosList newList = new SortedPosList();
            
            IEnumerable<Position> posInCircle = positions.Where(p => 
                (Math.Pow(p.X - centerPosition.X, 2) + (Math.Pow(p.Y - centerPosition.Y, 2))) < Math.Pow(radius, 2));

            foreach(Position p in posInCircle)
            {
                newList.Add(p.Clone());
            }
            return newList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newSortedPosList = sp1.Clone();
            foreach(Position p in sp2.positions)
            {
                newSortedPosList.Add(p.Clone());
            }
            return newSortedPosList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            IEnumerable<Position> posToRemove = sp1.Where(p1 => sp2.Any(p2 => p2.Equals(p1)));
            SortedPosList baseList = sp1.Clone();
            foreach(Position p in posToRemove) baseList.Remove(p);
            return baseList;
        }

        public Position this[int index]
        {
            get { return positions[index]; }
        }

        public override string ToString()
        {
            return string.Join(", ", positions);
        }
        
        public void DisplayList()
        {
            if(filePath != null)
            {
                Console.WriteLine($"The list '{filePath}' contains {Count()} positions:");
            }
            else
            {
                Console.WriteLine($"The list contains {Count()} positions:");
            }
            
            int i = 0;
            foreach(Position p in positions)
            {
                Console.WriteLine($"[{i++}]\t" + p + $"\t {p.Length()}");
            }
        }

        private void SortList()
        {
            positions.Sort((emp1, emp2) => emp1.Length().CompareTo(emp2.Length()));
        }

        private void Load(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] xy = line.Split(',');
                    xy[0] = Regex.Replace(xy[0], "[^0-9.]", "");
                    xy[1] = Regex.Replace(xy[1], "[^0-9.]", "");

                    int x = int.Parse(xy[0]);
                    int y = int.Parse(xy[1]);
                    Position position = new Position(x,y);
                    Add(position);
                }
            }
            catch (FileNotFoundException)
            {
                this.filePath = filePath;
                File.Create(filePath).Close();
                Console.WriteLine($"No file found, created: {filePath}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Error parsing: {filePath}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error reading: {filePath}");
            }
        }

        private void Save()
        {
            string[] positionsAsStrings = new string[positions.Count()];
            int index = 0;
            foreach(Position p in positions)
            {
                positionsAsStrings[index++] = p.ToString();
            }

            try
            {
                File.WriteAllLines(filePath, positionsAsStrings);
            }
            catch (Exception)
            {
                Console.WriteLine($"Could not write to file: {filePath}");
            }
        }

        public IEnumerator<Position> GetEnumerator()
        {
            return positions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
