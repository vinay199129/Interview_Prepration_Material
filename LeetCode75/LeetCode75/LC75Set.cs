using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode75
{
    /// <summary>
    /// Represents a set of methods for LeetCode problems.
    /// </summary>
    internal class LC75Set
    {
        /// <summary>
        /// Merges two strings alternately.
        /// </summary>
        /// <param name="word1">The first word.</param>
        /// <param name="word2">The second word.</param>
        /// <returns>The merged string.</returns>
        public string MergeAlternately(string word1, string word2)
        {
            int minLength = word1.Length > word2.Length ? word2.Length : word1.Length;

            string suffix = string.Empty;
            string prefix = string.Empty;
            if (word1.Length > minLength)
            {
                for (int i = minLength; i < word1.Length; i++)
                {
                    suffix += word1[i];
                }
            }
            else
            {
                for (int i = minLength; i < word2.Length; i++)
                {
                    suffix += word2[i];
                }
            }

            Console.WriteLine(suffix);

            for (int i = 0; i < minLength; i++)
            {
                prefix += word1[i];
                prefix += word2[i];
            }
            return prefix + suffix;
        }

        /// <summary>
        /// Merges two strings alternately using StringBuilder for better performance.
        /// </summary>
        /// <param name="word1">The first word.</param>
        /// <param name="word2">The second word.</param>
        /// <returns>The merged string.</returns>
        public string MergeAlternately2(string word1, string word2)
        {
            int minLength = word1.Length > word2.Length ? word2.Length : word1.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < minLength; i++)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
            }
            if (word1.Length > minLength)
            {
                for (int i = minLength; i < word1.Length; i++)
                {
                    sb.Append(word1[i]);
                }
            }
            else
            {
                for (int i = minLength; i < word2.Length; i++)
                {
                    sb.Append(word2[i]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Finds the greatest common divisor of two strings.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <returns>The greatest common divisor.</returns>
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length < str2.Length)
            {
                return GcdOfStrings(str2, str1);
            }
            else if (str2.Length == 0)
            {
                return str1;
            }
            else if (str1.StartsWith(str2))
            {
                return GcdOfStrings(str1.Substring(str2.Length), str2);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Checks if flowers can be placed in a flowerbed.
        /// </summary>
        /// <param name="flowerbed">The flowerbed array.</param>
        /// <param name="n">The number of flowers to place.</param>
        /// <returns>True if the flowers can be placed, otherwise false.</returns>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int totalPossibilities = 0;

            if (n == 0)
            {
                return true;
            }

            if (flowerbed.Length == 0)
            {
                return false;
            }

            if (flowerbed.Length == 1 && flowerbed[0] == 0 && n == 1)
            {
                return true;
            }
            if (flowerbed.Length == 1 && flowerbed[0] == 1 && n == 1)
            {
                return false;
            }

            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (i == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    flowerbed[i] = 1;
                    totalPossibilities++;
                }

                if (i > 0 && i < (flowerbed.Length - 1) && flowerbed[i - 1] == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    flowerbed[i] = 1;
                    totalPossibilities++;
                }

                if (i == (flowerbed.Length - 1) && flowerbed[i - 1] == 0 && flowerbed[i] == 0)
                {
                    flowerbed[i] = 1;
                    totalPossibilities++;
                }
            }

            return totalPossibilities >= n;
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandies = candies.Max();
            IList<bool> result = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= maxCandies)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }

        public string ReverseVowels(string s)
        {
            string vowels = "aeiouAEIOU";
            int left = 0;
            int right = s.Length - 1;
            char[] result = s.ToCharArray();
            while (left < right)
            {
                if (vowels.Contains(result[left]) && vowels.Contains(result[right]))
                {
                    char temp = result[left];
                    result[left] = result[right];
                    result[right] = temp;
                    left++;
                    right--;
                }
                else if (vowels.Contains(result[left]))
                {
                    right--;
                }
                else if (vowels.Contains(result[right]))
                {
                    left++;
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return new string(result);
        }

        public string ReverseWords(string s)
        {
            s = s.Trim();
            string[] words = s.Split(' ');
            words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i != 0)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int?[] result = new int?[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        if (result[i] == null)
                        {
                            result[i] = nums[j];
                        }
                        else
                        {
                            result[i] *= nums[j];
                        }
                    }
                }
            }
            return result.Select(x => Convert.ToInt32(x)).ToArray();
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            //base case
            if (nums.Length == 1)
            {
                return nums;
            }

            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];
            int[] prod = new int[nums.Length];

            //both extreme will always be 1
            left[0] = 1;
            right[nums.Length - 1] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                left[i] = nums[i - 1] * left[i - 1];
            }

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                right[i] = nums[i + 1] * right[i + 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                prod[i] = left[i] * right[i];
            }

            return prod;
        }

        public bool IncreasingTriplet(int[] nums)
        {
            int x = int.MaxValue, y = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int z = nums[i];
                if (x >= z)
                {
                    x = z;
                }
                else if (y > z)
                {
                    y = z;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public int Compress(char[] chars)
        {
            int ans = 0;
            for (int i = 0; i < chars.Length;)
            {
                char letter = chars[i];
                int count = 0;
                while (i < chars.Length && chars[i] == letter)
                {
                    ++count;
                    ++i;
                }
                chars[ans++] = letter;
                if (count > 1)
                {
                    foreach (char c in count.ToString())
                    {
                        chars[ans++] = c;
                    }
                }
            }
            return ans;
        }

        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            int lastNonZeroFoundAt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZeroFoundAt++] = nums[i];
                }
            }

            for (int i = lastNonZeroFoundAt; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

    }
    

}
