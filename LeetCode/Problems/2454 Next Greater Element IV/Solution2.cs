using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2454_Next_Greater_Element_IV;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-90/submissions/detail/832762673/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] SecondGreaterElement(int[] nums)
    {
        var result = Enumerable.Repeat(-1, nums.Length).ToArray();

        var waitingForFirstGreater = new List<(int num, int negateIndex)>();
        var waitingForSecondGreater = new List<(int num, int negateIndex)>();

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];

            (int num, int negateIndex) key = (num, -index);

            var insertPosition = InsertInSortedList(waitingForFirstGreater, key);

            var secondListPosition = ~waitingForSecondGreater.BinarySearch(key);

            for (var j = 0; j < secondListPosition; j++)
            {
                var lessKey = waitingForSecondGreater[0];
                result[-lessKey.negateIndex] = num;
                waitingForSecondGreater.RemoveAt(0);
            }

            for (var j = 0; j < insertPosition; j++)
            {
                var lessKey = waitingForFirstGreater[0];
                InsertInSortedList(waitingForSecondGreater, lessKey);
                waitingForFirstGreater.RemoveAt(0);
            }
        }

        return result;
    }

    private static int InsertInSortedList(List<(int num, int negateIndex)> sortedList, (int num, int negateIndex) key)
    {
        var insertPosition = ~sortedList.BinarySearch(key);
        sortedList.Insert(insertPosition, key);
        return insertPosition;
    }
}
