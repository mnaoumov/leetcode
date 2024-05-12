using JetBrains.Annotations;

namespace LeetCode.Problems._1535_Find_the_Winner_of_an_Array_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/1092336965/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int GetWinner(int[] arr, int k)
    {
        if (k >= arr.Length - 1)
        {
            return arr.Max();
        }

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
