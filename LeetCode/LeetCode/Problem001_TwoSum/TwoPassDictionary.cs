using System;
using System.Collections.Generic;

namespace LeetCode.Problem001_TwoSum
{
    public class TwoPassDictionary : ISolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var numberToIndexDict = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
                numberToIndexDict[nums[index]] = index;

            for (int index = 0; index < nums.Length; index++)
            {
                int complementIndex;
                var complementValue = target - nums[index];
                if (numberToIndexDict.TryGetValue(complementValue, out complementIndex) && complementIndex != index)
                {
                    return new[] {index, complementIndex};
                }
            }

            throw new ArgumentException();
        }
    }
}