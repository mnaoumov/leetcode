using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2517_Maximum_Tastiness_of_Candy_Basket;

/// <summary>
/// https://leetcode.com/submissions/detail/865497413/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumTastiness(int[] price, int k)
    {
        Array.Sort(price);

        var result = price[^1] - price[0];

        var indicesTaken = new List<int> { 0, price.Length - 1 };

        for (var i = 3; i <= k; i++)
        {
            var candidates = new List<(int indicesTakenInsertIndex, int midIndex, int tastiness)>();

            for (var j = 0; j < indicesTaken.Count - 1; j++)
            {
                var leftIndex = indicesTaken[j];
                var rightIndex = indicesTaken[j + 1];
                var leftPrice = price[leftIndex];
                var rightPrice = price[rightIndex];
                var midPrice = (leftPrice + rightPrice) / 2;
                var midIndex = Array.BinarySearch(price, leftIndex + 1, rightIndex - leftIndex, midPrice);

                if (midIndex < 0)
                {
                    midIndex = ~midIndex;
                    AddCandidate(midIndex - 1);
                }

                AddCandidate(midIndex);
                continue;

                void AddCandidate(int candidateMidIndex)
                {
                    var candidatePrice = price[candidateMidIndex];
                    var tastiness = Math.Min(candidatePrice - leftPrice, rightPrice - candidatePrice);
                    candidates.Add((j + 1, candidateMidIndex, tastiness));
                }
            }

            var bestCandidate = candidates.MaxBy(candidate => candidate.tastiness);
            indicesTaken.Insert(bestCandidate.indicesTakenInsertIndex, bestCandidate.midIndex);
            result = bestCandidate.tastiness;
        }

        return result;
    }
}
