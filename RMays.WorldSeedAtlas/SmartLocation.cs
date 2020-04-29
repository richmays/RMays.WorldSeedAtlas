using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    public class SmartLocation : Location, IComparable<SmartLocation>
    {
        public bool Checked { get; set; } = false;
        public bool Visible { get; set; } = true;
        public int Distance { get; set; } = 999;

        public int CompareTo(SmartLocation other)
        {
            if (this.Distance < other.Distance) return -1;
            if (this.Distance > other.Distance) return 1;
            return this.ToString().CompareTo(other.ToString());
        }

        public void RecalculateDistance(string currentLocation)
        {
            Distance = DistanceCalculator.GetDistance(currentLocation, $"{this.XCoord}{this.YCoord}");
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.BossName))
            {
                return $"{Distance} - {Name} - {XCoord}{YCoord}";
            }
            else
            {
                return $"{Distance} - {Name} ({BossName}) - {XCoord}{YCoord}";
            }
        }
    }
}
