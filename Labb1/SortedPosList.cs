using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Labb1
{
    public class SortedPosList
    {
        private List<Position> _positions = new List<Position>();
        private string _filePath { get; set; }

        public SortedPosList() { }

        public SortedPosList(string filePath)
        {
            _filePath = filePath;
            Load(filePath);
        }

        public int Count()
        {
            return _positions.Count();
        }

        public void Add(Position p)
        {
            _positions.Add(p);
            SortList();
            if(_filePath != null) Save();
        }

        public bool Remove(Position p)
        {
            int positionsRemoved = _positions.RemoveAll(pos => pos.Equals(p));
            if(positionsRemoved > 0)
            {
                if(_filePath != null) Save();
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
            foreach (Position p in _positions)
            {
                newList.Add(p.Clone());
            }
            newList.SortList();
            return newList;
        }

        public SortedPosList CircleContent(Position centerPosition, double radius)
        {
            SortedPosList newList = new SortedPosList();
            foreach(Position p in _positions)
            {
                if ((Math.Pow(p.X - centerPosition.X, 2) + (Math.Pow(p.Y - centerPosition.Y, 2))) < Math.Pow(radius, 2))
                {
                    newList.Add(p.Clone());
                }
            }
            return newList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newSortedPosList = sp1.Clone();
            foreach(Position p in sp2._positions)
            {
                newSortedPosList.Add(p.Clone());
            }
            return newSortedPosList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            int baseIndex = 0;
            int subIndex = 0;
            SortedPosList baseList = sp1.Clone();
            SortedPosList subList = sp2;
            while (baseIndex < baseList.Count() && subIndex < subList.Count())
            {
                if(baseList[baseIndex].Equals(subList[subIndex]))
                {
                    baseList.Remove(baseList[baseIndex]);
                }
                else
                {
                    if (baseList[baseIndex].Length() >= subList[subIndex].Length()) subIndex++;
                    else baseIndex++;
                }
            }
            return baseList;
        }

        public Position this[int index]
        {
            get { return _positions[index]; }
        }

        public override string ToString()
        {
            return string.Join(", ", _positions);
        }
        
        public void DisplayList()
        {
            if(_filePath != null)
            {
                Console.WriteLine($"The list '{_filePath}' contains {Count()} positions:");
            }
            else
            {
                Console.WriteLine($"The list contains {Count()} positions:");
            }
            
            int i = 0;
            foreach(Position p in _positions)
            {
                Console.WriteLine($"[{i++}]\t" + p + $"\t {p.Length()}");
            }
        }

        private void SortList()
        {
            _positions.Sort((emp1, emp2) => emp1.Length().CompareTo(emp2.Length()));
        }

        private void Load(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    int startX = line.IndexOf('(') + 1;
                    int endX = line.IndexOf(',');
                    int startY = line.IndexOf(',') + 1;
                    int endY = line.IndexOf(')');

                    int x = int.Parse(line.Substring(startX, endX - startX));
                    int y = int.Parse(line.Substring(startY, endY - startY));
                    Position position = new Position(x,y);
                    Add(position);
                }
            }
            catch (FileNotFoundException)
            {
                this._filePath = filePath;
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
            string[] positionsAsStrings = new string[_positions.Count()];
            int index = 0;
            foreach(Position p in _positions)
            {
                positionsAsStrings[index++] = p.ToString();
            }

            try
            {
                File.WriteAllLines(_filePath, positionsAsStrings);
            }
            catch (Exception)
            {
                Console.WriteLine($"Could not write to file: {_filePath}");
            }
        }
    }
}
