using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingProblems
{
    /// <summary>
    /// Take a target sum and an array of number, now we can have two types of problems.
    /// 1. Calc if we can reach the target sum with same numbers from array.Number are non negative and can be reused.
    /// 2. Get the combination from the array which can reach the target sum(at least 1), numbers can be reused.
    /// 3. Get the best sum which is equal to target with least numbers
    /// </summary>
    public static class SummingProblems
    {
        /// <summary>
        /// Without Memo => Time  O(numbers.length^targetSum) | |Space is O(targetsum)
        /// With Memo => Time  O(numbers.length * targetSum) | |Space is O(targetsum)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static bool CanSum(int targetSum, int[] numbers, Dictionary<int, bool>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<int, bool>();
            if (calculations.ContainsKey(targetSum)) return calculations[targetSum];
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            foreach (int num in numbers)
            {
                int remainder = targetSum - num;
                if (CanSum(remainder, numbers, calculations))
                {
                    calculations[targetSum] = true;
                    return true;
                }
            }
            calculations[targetSum] = false;
            return false;
        }

        /// <summary>
        /// Without Memo => Time  O((numbers.length^targetSum)*targetSum) | |Space is O(targetsum)
        /// With Memo => Time  O(numbers.length * targetSum * targetSum) | |Space is O(targetsum*targetsum)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static int[]? HowSum(int targetSum, int[] numbers, Dictionary<int, int[]?>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<int, int[]?>();
            if (calculations.ContainsKey(targetSum)) return calculations[targetSum];
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            foreach (int num in numbers)
            {
                int remainder = targetSum - num;
                int[]? remainderResult = HowSum(remainder, numbers, calculations);
                if (remainderResult != null)
                {
                    remainderResult = remainderResult.Append(num).ToArray();
                    calculations[targetSum] = remainderResult;
                    return calculations[targetSum];
                }
            }
            calculations[targetSum] = null;
            return null;
        }

        /// <summary>
        /// Without Memo => Time  O(numbers.length^targetSum*targetSum) | |Space is O(targetsum*targetsum)
        /// With Memo => Time  O(numbers.length * targetSum * targetSum) | |Space is O(targetsum*targetsum)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static int[]? BestSum(int targetSum, int[] numbers, Dictionary<int, int[]?>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<int, int[]?>();
            if (calculations.ContainsKey(targetSum)) return calculations[targetSum];
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            int[]? shortestCombination = null;

            foreach (int num in numbers)
            {
                int remainder = targetSum - num;
                int[]? remainderCombination = BestSum(remainder, numbers, calculations);
                if (remainderCombination != null)
                {
                    int[]? currentCombination = remainderCombination.Append(num).ToArray();
                    if (shortestCombination == null || currentCombination.Length < shortestCombination.Length) { 
                        shortestCombination = currentCombination;
                    }
                }
            }
            calculations[targetSum] = shortestCombination;
            return shortestCombination;
        }

    }
}
