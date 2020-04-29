using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    public class LocationList : ICollection<Location>
    {
        internal List<Location> Locations { get; set; }

        #region Interface Implementation: ICollection<Location>
        public int Count => Locations.Count;

        public bool IsReadOnly => false;

        public void Add(Location item)
        {
            Locations.Add(item);
        }

        public void Clear()
        {
            Locations.Clear();
        }

        public bool Contains(Location item)
        {
            return Locations.Contains(item);
        }

        public void CopyTo(Location[] array, int arrayIndex)
        {
            Locations.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Location> GetEnumerator()
        {
            return Locations.GetEnumerator();
        }

        public bool Remove(Location item)
        {
            return Locations.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Locations.GetEnumerator();
        }
        #endregion

        public LocationList(string filename)
        {
            // Defines what the files looks like: a list of LocationTypes, and a list of Locations.
            var locationFileDefinition = new { LocationTypes = new List<string>(), Locations = new List<Location>() };

            // Read the entire file into a string.
            var locationFileContents = new StreamReader(filename).ReadToEnd();

            // Convert the string into a list of LocationTypes and Locations.
            var locationData = JsonConvert.DeserializeAnonymousType(locationFileContents, locationFileDefinition);



        }
    }
}
