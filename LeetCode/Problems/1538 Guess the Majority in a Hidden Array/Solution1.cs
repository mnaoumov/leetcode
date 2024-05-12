using JetBrains.Annotations;

namespace LeetCode._1538_Guess_the_Majority_in_a_Hidden_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/941725714/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int GuessMajority(ArrayReader reader)
    {
        var n = reader.Length();

        var q0123 = reader.Query(0, 1, 2, 3);
        var q1234 = reader.Query(1, 2, 3, 4);

        var countEqualToFirst = q0123 switch
        {
            4 => 4,
            0 => 2,
            2 => 1,
            _ => throw new InvalidOperationException()
        };

        var indexOfNonEqualValue = -1;

        for (var i = 4; i < n; i++)
        {
            var q123I = i == 4 ? q1234 : reader.Query(1, 2, 3, i);

            if (q123I == q0123)
            {
                countEqualToFirst++;
            }
            else
            {
                indexOfNonEqualValue = i;
            }
        }

        if (q0123 == 2 && (reader.Query(0, 2, 3, 4) == 2
                           || reader.Query(0, 1, 3, 4) == 2
                           || reader.Query(0, 1, 2, 4) == 2))
        {
            countEqualToFirst += 2;
        }

        return 2 * countEqualToFirst == n ? -1 : 2 * countEqualToFirst > n ? 0 : indexOfNonEqualValue;
    }
}
