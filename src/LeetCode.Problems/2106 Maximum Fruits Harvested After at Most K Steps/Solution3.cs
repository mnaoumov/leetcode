namespace LeetCode.Problems._2106_Maximum_Fruits_Harvested_After_at_Most_K_Steps;

/// <summary>
/// https://leetcode.com/problems/maximum-fruits-harvested-after-at-most-k-steps/submissions/1721403294/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        var fruitObjs = fruits.Select(arr => new Fruit(arr[0], arr[1])).ToArray();
        var positionComparer = Comparer<Fruit>.Create((a, b) => a.Position.CompareTo(b.Position));
        var startIndex = Array.BinarySearch(fruitObjs, new Fruit(startPos, 0), positionComparer);

        var amountAtStart = startIndex >= 0
            ? fruitObjs[startIndex].Amount
            : 0;
        var amountsToLeft = new Dictionary<int, int>();
        var amountsToRight = new Dictionary<int, int>();

        var amount = 0;

        for (var i = startIndex >= 0 ? startIndex - 1 : ~startIndex - 1; i >= 0; i--)
        {
            var fruit = fruitObjs[i];

            if (fruit.Position < startPos - k)
            {
                break;
            }

            amount += fruit.Amount;
            amountsToLeft[fruit.Position] = amount;
        }

        amount = 0;

        for (var i = startIndex >= 0 ? startIndex + 1 : ~startIndex; i < fruitObjs.Length; i++)
        {
            var fruit = fruitObjs[i];

            if (fruit.Position > startPos + k)
            {
                break;
            }

            amount += fruit.Amount;
            amountsToRight[fruit.Position] = amount;
        }

        var ans = amountAtStart;

        foreach (var (positionLeft, totalAmountToLeft) in amountsToLeft)
        {
            var maxPositionRight = startPos + k - 2 * (startPos - positionLeft);

            var totalAmountToRight = 0;

            if (maxPositionRight > startPos)
            {
                var index = Array.BinarySearch(fruitObjs, new Fruit(maxPositionRight, 0), positionComparer);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (0 <= index && index < fruitObjs.Length)
                {
                    maxPositionRight = fruitObjs[index].Position;
                    totalAmountToRight = amountsToRight.GetValueOrDefault(maxPositionRight, 0);
                }
            }

            ans = Math.Max(ans, amountAtStart + totalAmountToLeft + totalAmountToRight);
        }

        foreach (var (positionRight, totalAmountToRight) in amountsToRight)
        {
            var minPositionLeft = startPos - (k - 2 * (positionRight - startPos));

            var totalAmountToLeft = 0;

            if (minPositionLeft < startPos)
            {
                var index = Array.BinarySearch(fruitObjs, new Fruit(minPositionLeft, 0), positionComparer);

                if (index < 0)
                {
                    index = ~index;
                }

                if (0 <= index && index < fruitObjs.Length)
                {
                    minPositionLeft = fruitObjs[index].Position;
                    totalAmountToLeft = amountsToRight.GetValueOrDefault(minPositionLeft, 0);
                }
            }

            ans = Math.Max(ans, amountAtStart + totalAmountToLeft + totalAmountToRight);
        }

        return ans;
    }

    private record Fruit(int Position, int Amount);
}
