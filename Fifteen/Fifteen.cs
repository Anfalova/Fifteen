using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }
    internal bool isAdjacent(Location nextElement)
    {
        if ((nextElement.X - X == 0 && Math.Abs(nextElement.Y - Y) == 1)
            || (nextElement.Y - Y == 0 && Math.Abs(nextElement.X - X) == 1))
            return true;
        else return false;
    }
}


namespace Fifteen
{
    public class Game
    {
        private int[,] playingField;
        Location[] currentLocation;
        public Game(params int[] values)
        {
            if (values.Length < 4)
                throw new ArgumentException("Too few arguments.");
            else
            {
                double lengthSqrt = Math.Sqrt(values.Length);
                int side = Convert.ToInt32(lengthSqrt);
                if (lengthSqrt != side)
                    throw new ArgumentException("Playing field isn't squared.");
                else
                {
                    bool b = false;
                    for (int i = 0; i < values.Length; i++)
                        for (int j = i + 1; j < values.Length; j++)
                            if (values[i] == values[j] || values[i] >= values.Length)
                                b = true;
                    if (b)
                        throw new ArgumentException("Numeric values is not correct.");
                    else
                    {
                        playingField = new int[side, side];
                        currentLocation = new Location[values.Length];
                        for (int i = 0; i < side; i++)
                            for (int j = 0; j < side; j++)
                            {
                                playingField[i, j] = values[i * side + j];
                                currentLocation[values[i * side + j]] =
                                new Location { X = i, Y = j };
                            }
                    }
                }
            }
        }
        public Location GetLocation(int value)
        {
            return currentLocation[value];
        }

        public int this[int x, int y]
        {
            get
            {
                return playingField[x, y];
            }
        }

        public int this[Location coordinate]
        {
            get
            {
                return playingField[coordinate.X, coordinate.Y];
            }
        }
        public void Shift(int value)
        {
            if (currentLocation[value].isAdjacent(currentLocation[0]))
            {
                playingField[currentLocation[value].X, currentLocation[value].Y] = 0;
                playingField[currentLocation[0].X, currentLocation[0].Y] = value;
                Location temp = currentLocation[value];
                currentLocation[value] = currentLocation[0];
                currentLocation[0] = temp;
            }
            else
                throw new ArgumentException("Element not adjacent to zero.");
        }
    }
}
