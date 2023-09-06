using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingProblems
{
    /// <summary>
    /// Take a target sum and an array of number, now we can have two types of problems.
    /// 1. Calc if we can construct a string by given set of subStrings.
    /// </summary>
    public static class StringCases
    {
        /// <summary>
        /// Without Memo => Time  O(targetString.length^targetString) | |Space is O(targetString)
        /// With Memo => Time  O(targetString.length * targetString) | |Space is O(targetString)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static bool CanConstruct(string targetString, string[] subStrings, Dictionary<string, bool>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<string, bool>();
            if (calculations.ContainsKey(targetString)) return calculations[targetString];
            if (string.IsNullOrEmpty(targetString)) return true;

            foreach (string subString in subStrings)
            {
                if (targetString.StartsWith(subString))
                {
                    string suffix = targetString.Substring(subString.Length, (targetString.Length - subString.Length));
                    if (CanConstruct(suffix, subStrings))
                    {
                        calculations[targetString] = true;
                        return true;
                    }
                }
            }
            calculations[targetString] = false;
            return false;
        }

        /// <summary>
        /// Without Memo => Time  O(targetString.length^targetString) | |Space is O(targetString)
        /// With Memo => Time  O(targetString.length * targetString) | |Space is O(targetString)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static int CountConstruct(string targetString, string[] subStrings, Dictionary<string, int>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<string, int>();
            if (calculations.ContainsKey(targetString)) return calculations[targetString];
            if (string.IsNullOrEmpty(targetString)) return 1;

            int totalNumberOfWays = 0;

            foreach (string subString in subStrings)
            {
                if (targetString.StartsWith(subString))
                {
                    string suffix = targetString.Substring(subString.Length, (targetString.Length - subString.Length));
                    int numberOfWays = CountConstruct(suffix, subStrings, calculations);
                    totalNumberOfWays += numberOfWays;
                }
            }

            calculations[targetString] = totalNumberOfWays;
            return totalNumberOfWays;
        }

        /// <summary>
        /// Without Memo => Time  O(subStrings.length^targetString*targetString) | |Space is O(targetString)
        /// With Memo => Time  O(subStrings.length * targetString * targetString) | |Space is O(targetString*targetString)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="calculations"></param>
        /// <returns></returns>
        public static string[][] AllConstruct(string targetString, string[] subStrings, Dictionary<string, string[][]>? calculations = null)
        {
            calculations = calculations ?? new Dictionary<string, string[][]>();
            if (calculations.ContainsKey(targetString)) return calculations[targetString];
            if (string.IsNullOrEmpty(targetString)) return new string[][] { };

            string[][] result = new string[][] { };

            foreach (string subString in subStrings)
            {
                if (targetString.StartsWith(subString))
                {
                    string suffix = targetString.Substring(subString.Length, (targetString.Length - subString.Length));
                    string[][] suffixWays = AllConstruct(suffix, subStrings, calculations);
                    string[][] targetWays = new string[][] { };

                    if (suffixWays.Length == 0 && suffix == "")
                    {
                        targetWays = targetWays.Append(new string[] { subString }).ToArray();
                    }
                    else
                    {
                        for (int i = 0; i < suffixWays.Length; i++)
                        {
                            targetWays = targetWays.Append(suffixWays[i].Prepend(subString).ToArray()).ToArray();
                        }
                    }

                    for (int i = 0; i < targetWays.Length; i++)
                    {
                        result = result.Append(targetWays[i]).ToArray();
                    }
                }
            }
            calculations[targetString] = result;
            return result;
        }

    }
}
