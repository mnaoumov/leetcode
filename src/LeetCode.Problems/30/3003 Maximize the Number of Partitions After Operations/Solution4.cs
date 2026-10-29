namespace LeetCode.Problems._3003_Maximize_the_Number_of_Partitions_After_Operations;

/// <summary>
/// https://leetcode.com/problems/maximize-the-number-of-partitions-after-operations/submissions/1804703203/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxPartitionsAfterOperations(string s, int k)
    {
        const int alphabetSize = 26;
        var length = s.Length;

        if (k >= alphabetSize)
        {
            return 1;
        }

        var leftPrefixStates = new PartitionState[length];

        var closedPartitionsCount = 0;
        var openPartitionDistinctLetters = new HashSet<char>();
        for (var i = 0; i < length; i++)
        {
            leftPrefixStates[i] = new PartitionState(closedPartitionsCount, openPartitionDistinctLetters.ToHashSet());

            var letter = s[i];
            if (openPartitionDistinctLetters.Contains(letter))
            {
                continue;
            }

            if (openPartitionDistinctLetters.Count < k)
            {
                openPartitionDistinctLetters.Add(letter);
            }
            else
            {
                closedPartitionsCount++;
                openPartitionDistinctLetters = new HashSet<char> { letter };
            }
        }

        var rightSuffixStates = new PartitionState[length];
        closedPartitionsCount = 0;
        openPartitionDistinctLetters = new HashSet<char>();
        for (var i = length - 1; i >= 0; i--)
        {
            rightSuffixStates[i] = new PartitionState(closedPartitionsCount, openPartitionDistinctLetters.ToHashSet());

            var letter = s[i];
            if (openPartitionDistinctLetters.Contains(letter))
            {
                continue;
            }

            if (openPartitionDistinctLetters.Count < k)
            {
                openPartitionDistinctLetters.Add(letter);
            }
            else
            {
                closedPartitionsCount++;
                openPartitionDistinctLetters = new HashSet<char> { letter };
            }
        }

        var ans = 0;

        for (var i = 0; i < length; i++)
        {
            var leftState = leftPrefixStates[i];
            var rightState = rightSuffixStates[i];

            var basePartitionsCount = leftState.ClosedPartitionsCount + rightState.ClosedPartitionsCount + 2;

            var leftOpenPartitionDistinctLetters = leftState.OpenPartitionDistinctLetters.Count;
            var rightOpenPartitionDistinctLetters = rightState.OpenPartitionDistinctLetters.Count;

            var allDistinctLetters = leftState.OpenPartitionDistinctLetters.ToHashSet();
            allDistinctLetters.UnionWith(rightState.OpenPartitionDistinctLetters);

            var canIsolateChangedChar =
                leftOpenPartitionDistinctLetters == k
                && rightOpenPartitionDistinctLetters == k
                && allDistinctLetters.Count < alphabetSize;

            var canMergeOpenPartitions = Math.Min(allDistinctLetters.Count + 1, alphabetSize) <= k;

            var candidateTotal =
                basePartitionsCount
                + (canIsolateChangedChar ? 1 : 0)
                - (!canIsolateChangedChar && canMergeOpenPartitions ? 1 : 0);

            ans = Math.Max(ans, candidateTotal);
        }

        return ans;
    }

    private record PartitionState(int ClosedPartitionsCount, HashSet<char> OpenPartitionDistinctLetters);
}
