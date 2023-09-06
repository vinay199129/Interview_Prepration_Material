using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingProblems
{
    /// <summary>
    /// Calculate in how many ways we can traverse a m*n grid if we can only move down or right.
    /// </summary>
    public static class GridTraveller
    {
        /// <summary>
        /// Without Memo => Time  O(2^n+m) | |Space is O(n+m)
        /// With Memo => Time  O(n+m) | |Space is O(n+m)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static long Calc(int m, int n, Dictionary<string, long>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<string, long>();
            string key = $"{m}||{n}";
            if(calculations.ContainsKey(key)) return calculations[key];
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;
            return calculations[key] = Calc(m - 1, n, calculations) + Calc(m, n - 1, calculations);
        }
    }
}
