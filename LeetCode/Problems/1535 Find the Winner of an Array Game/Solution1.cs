namespace LeetCode.Problems._1535_Find_the_Winner_of_an_Array_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/1092335891/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int GetWinner(int[] arr, int k)
    {
        var list = new LinkedList<int>();

        foreach (var num in arr)
        {
            list.AddLast(num);
        }

        var winCount = 0;

        while (winCount < k)
        {
            var firstNode = list.First!;
            var secondNode = firstNode.Next!;

            if (firstNode.Value > secondNode.Value)
            {
                winCount++;
                list.Remove(secondNode);
                list.AddLast(secondNode);
            }
            else
            {
                winCount = 1;
                list.Remove(firstNode);
                list.AddLast(firstNode);
            }
        }

        return list.First!.Value;
    }
}
