namespace LeetCode.Problems._2454_Next_Greater_Element_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/832793040/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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

            for (var j = secondListPosition - 1; j >= 0; j--)
            {
                var lessKey = waitingForSecondGreater[j];

                if (lessKey.num == int.MinValue)
                {
                    break;
                }

                result[-lessKey.negateIndex] = num;
                waitingForSecondGreater[j] = (int.MinValue, 0);
            }

            for (var j = insertPosition - 1; j >= 0; j--)
            {
                var lessKey = waitingForFirstGreater[j];

                if (lessKey.num == int.MinValue)
                {
                    break;
                }

                InsertInSortedList(waitingForSecondGreater, lessKey);
                waitingForFirstGreater[j] = (int.MinValue, 0);
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
