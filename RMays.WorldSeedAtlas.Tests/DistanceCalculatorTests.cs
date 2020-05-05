using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas.Tests
{
    [TestFixture]
    public class DistanceCalculatorTests
    {
        // from X to X
        [TestCase("A1", "A1", 0)]
        [TestCase("AB28", "AB28", 0)]

        // Neighbor
        [TestCase("A1", "A2", 1)]
        [TestCase("Y22", "Z22", 1)]
        [TestCase("AB28", "A28", 1)]
        [TestCase("A28", "AB28", 1)]
        [TestCase("A1", "AB1", 1)]
        [TestCase("AB1", "A1", 1)]

        // Caddycorner Neighbor
        [TestCase("A1", "B2", 2)]

        // Far away
        [TestCase("A1", "O14", 27)]
        [TestCase("A1", "O15", 28)]
        [TestCase("A1", "O16", 27)]
        [TestCase("AB28", "N13", 27)]
        [TestCase("AB28", "N14", 28)]
        [TestCase("AB28", "N15", 27)]

        // Invalid location
        [TestCase("A1", "ZA1", -1)]
        [TestCase("A1", "AC1", -1)]
        [TestCase("A1", "1A", -1)]
        [TestCase("A1", "BA1", -1)]
        [TestCase("A1", "hafasghafavdgasdsd", -1)]
        [TestCase(null, null, -1)]
        [TestCase("A1", null, -1)]
        public void CalculateDistanceTests(string loc1, string loc2, int expectedResult)
        {
            var result = DistanceCalculator.GetDistance(loc1, loc2);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
