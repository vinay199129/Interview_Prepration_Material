using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode75
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LC75Set lc75Set = new LC75Set();
            // lc75Set.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1);
            //lc75Set.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            lc75Set.IncreasingTriplet(new int[] { 20, 100, 10, 12, 5, 13 });
        }
    }
}
