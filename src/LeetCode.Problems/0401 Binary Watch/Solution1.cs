namespace LeetCode.Problems._0401_Binary_Watch;

/// <summary>
/// https://leetcode.com/problems/binary-watch/submissions/1921652804/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        var deltas = new (int hour, int minute)[]
        {
            (1, 0),
            (2, 0),
            (4, 0),
            (8, 0),
            (0, 1),
            (0, 2),
            (0, 4),
            (0, 8),
            (0, 16),
            (0, 32)
        };


        var hour = 0;
        var minute = 0;
        var takenCount = 0;
        var ans = new List<string>();
        Backtrack(0);

        return ans;

        void Backtrack(int deltaIndex)
        {
            if (takenCount == turnedOn)
            {
                if (hour < 12 && minute < 60)
                {
                    ans.Add($"{hour}:{minute:D2}");
                }
                return;
            }

            hour += deltas[deltaIndex].hour;
            minute += deltas[deltaIndex].minute;
            takenCount++;
            Backtrack(deltaIndex + 1);
            hour -= deltas[deltaIndex].hour;
            minute -= deltas[deltaIndex].minute;
            takenCount--;

            if (deltas.Length - deltaIndex > turnedOn - takenCount)
            {
                Backtrack(deltaIndex + 1);
            }
        }
    }
}
