using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    [Serializable]
    public class Location : IComparable<Location>
    {
        public string Name { get; set; }
        public string BossName { get; set; }
        public string Type { get; set; }
        public string XCoord { get; set; }
        public string YCoord { get; set; }

        public virtual int CompareTo(Location other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.BossName))
            {
                return $"{Name} - {XCoord}{YCoord}";
            }
            else
            {
                return $"{Name} ({BossName}) - {XCoord}{YCoord}";
            }
        }
    }
}
