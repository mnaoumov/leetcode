namespace LeetCode.Problems._1718_Construct_the_Lexicographically_Largest_Valid_Sequence;

/// <summary>
/// https://leetcode.com/problems/construct-the-lexicographically-largest-valid-sequence/submissions/1545186668/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ConstructDistancedSequence(int n)
    {
        const int unset = 0;
        var length = 2 * n - 1;
        var ans = new int[length];
        var availableNumbers = new SortedSet<int>(Enumerable.Range(1, n), Comparer<int>.Create((a, b) => b - a));
        Init(0);
        return ans;

        bool Init(int index)
        {
            if (index == length)
            {
                return true;
            }

            if (ans[index] != unset)
            {
                // ReSharper disable once TailRecursiveCall
                return Init(index + 1);
            }

            foreach (var number in availableNumbers.ToArray())
            {
                var nextIndex = index + (number == 1 ? 0 : number);
                if (nextIndex >= length || ans[nextIndex] != unset)
                {
                    continue;
                }

                ans[index] = number;
                ans[nextIndex] = number;
                availableNumbers.Remove(number);

                if (Init(index + 1))
                {
                    return true;
                }

                ans[index] = unset;
                ans[nextIndex] = unset;
                availableNumbers.Add(number);
            }

            return false;
        }
    }
}
