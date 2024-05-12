using JetBrains.Annotations;

namespace LeetCode._2454_Next_Greater_Element_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/833861203/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] SecondGreaterElement(int[] nums)
    {
        var result = Enumerable.Repeat(-1, nums.Length).ToArray();

        var waitingForFirstGreaterIndices = new Stack<int>();
        var waitingForSecondGreaterIndices = new Stack<int>();
        var tempStackToReverse = new Stack<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            while (waitingForSecondGreaterIndices.TryPeek(out var index) && num > nums[index])
            {
                result[index] = num;
                waitingForSecondGreaterIndices.Pop();
            }

            while (waitingForFirstGreaterIndices.TryPeek(out var index) && num > nums[index])
            {
                waitingForFirstGreaterIndices.Pop();
                tempStackToReverse.Push(index);
            }

            while (tempStackToReverse.TryPop(out var index))
            {
                waitingForSecondGreaterIndices.Push(index);
            }

            waitingForFirstGreaterIndices.Push(i);
        }

        return result;
    }
}
