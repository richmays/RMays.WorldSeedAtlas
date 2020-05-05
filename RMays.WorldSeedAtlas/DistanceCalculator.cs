using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    public static class DistanceCalculator
    {
        internal class Coord
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public Coord() { }

            public Coord(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public override string ToString()
            {
                return $"({Row},{Col})";
            }
        }

        public static int GetDistance(string loc1, string loc2)
        {
            Coord coord1;
            Coord coord2;
            if (!TryGetCoord(loc1, out coord1)) return -1;
            if (!TryGetCoord(loc2, out coord2)) return -1;

            return Math.Min((28 + coord1.Row - coord2.Row) % 28, (28 + coord2.Row - coord1.Row) % 28)
                + Math.Min((28 + coord1.Col - coord2.Col) % 28, (28 + coord2.Col - coord1.Col) % 28);
        }

        private static bool TryGetCoord(string loc, out Coord result)
        {
            result = new Coord();

            // Is it too short or too long?  Location must be exactly 2, 3, or 4 characters.
            if (loc == null || loc.Length < 2 || loc.Length > 4)
            {
                return false;
            }

            // Normalize it to upper-case.
            loc = loc.ToUpper();

            string rowPart = string.Empty;
            string colPart = string.Empty;
            if (loc.Length == 2)
            {
                rowPart = loc.Substring(0, 1);
                colPart = loc.Substring(1, 1);
            }
            else if (loc.Length == 3)
            {
                char c = loc[1];
                if (c >= '0' && c <= '9')
                {
                    rowPart = loc.Substring(0, 1);
                    colPart = loc.Substring(1, 2);
                }
                else
                {
                    rowPart = loc.Substring(0, 2);
                    colPart = loc.Substring(2, 1);
                }
            }
            else if (loc.Length == 4)
            {
                rowPart = loc.Substring(0, 2);
                colPart = loc.Substring(2, 2);
            }

            // Now check each one.
            if (rowPart.Length == 1)
            {
                if (rowPart[0] >= 'A' && rowPart[0] <= 'Z')
                {
                    // Convert the single-character row to a number from 0 to 25.
                    result.Row = rowPart[0] - 'A';
                }
                else
                {
                    return false;
                }
            }
            else if (rowPart.Length == 2)
            {
                switch(rowPart)
                {
                    case "AA":
                        result.Row = 26;
                        break;
                    case "AB":
                        result.Row = 27;
                        break;
                    default:
                        // Invalid two-character code; expected 'AA' or 'AB'.
                        return false;
                }
            }
            else
            {
                // Rowpart wasn't length 1 or 2.
                return false;
            }

            if (!int.TryParse(colPart, out int colTemp))
            {
                // Column part wasn't an integer.
                return false;
            }

            if (colTemp >= 1 && colTemp <= 28)
            {
                result.Col = colTemp - 1;
            }
            else
            {
                // Column part was out of range.
                return false;
            }

            return true;
        }
    }
}
