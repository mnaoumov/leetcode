namespace LeetCode.Problems._2337_Move_Pieces_to_Obtain_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1470606374/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanChange(string start, string target)
    {
        var n = start.Length;
        var startIndex = 0;
        var targetIndex = 0;
        const char blank = '_';
        const char left = 'L';
        const char right = 'R';

        while (true)
        {
            while (startIndex < n && start[startIndex] == blank)
            {
                startIndex++;
            }

            while (targetIndex < n && target[targetIndex] == blank)
            {
                targetIndex++;
            }

            if (startIndex == n && targetIndex == n)
            {
                return true;
            }

            if (startIndex == n || targetIndex == n)
            {
                return false;
            }

            var startLetter = start[startIndex];
            var targetLetter = target[targetIndex];

            if (startLetter != targetLetter)
            {
                return false;
            }

            switch (startLetter)
            {
                case left when targetIndex > startIndex:
                case right when targetIndex < startIndex:
                    return false;
            }

            startIndex++;
            targetIndex++;
        }
    }
}
