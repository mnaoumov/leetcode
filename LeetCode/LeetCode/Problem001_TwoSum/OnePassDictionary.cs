using System;
using System.Collections.Generic;

namespace LeetCode.Problem001_TwoSum
{
    public class OnePassDictionary : ISolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var numberToIndexDict = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                int complementIndex;
                var complementValue = target - nums[index];
                if (numberToIndexDict.TryGetValue(complementValue, out complementIndex))
                {
                    return new[] {complementIndex, index};
                }

                numberToIndexDict[nums[index]] = index;
            }

            throw new ArgumentException();
        }
    }
}