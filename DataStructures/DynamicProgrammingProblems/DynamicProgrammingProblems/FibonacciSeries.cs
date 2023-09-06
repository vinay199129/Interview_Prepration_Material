using System.Collections;

namespace DynamicProgrammingProblems
{
    public static class FibonacciSeries
    {
        /// <summary>
        /// Without Memo => Time  O(2^n) | |Space is O(n)
        /// With Memo => Time  O(n) | |Space is O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static long Calc(int n, Dictionary<int, long>? calculations = null)
        {
            if (calculations == null ) {
                calculations = new Dictionary<int, long>();
            }
            if (calculations.ContainsKey(n)) {
                Console.WriteLine($"Value Present for {n}");
                return calculations[n];
            }            
            if (n <= 2) return 1;
            Console.WriteLine($"Calculating fib of {n}");
            calculations.Add(n, Calc(n - 1, calculations) + Calc(n - 2, calculations));
            return calculations[n];
        }
    }
}