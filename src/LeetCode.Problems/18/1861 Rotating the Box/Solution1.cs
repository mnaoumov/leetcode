namespace LeetCode.Problems._1861_Rotating_the_Box;

/// <summary>
/// https://leetcode.com/submissions/detail/1460400115/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char[][] RotateTheBox(char[][] box)
    {
        var m = box.Length;
        var n = box[0].Length;
        const char stone = '#';
        const char empty = '.';
        const char obstacle = '*';
        var ans = Enumerable.Range(0, n).Select(_ => Enumerable.Repeat(empty, m).ToArray()).ToArray();


        var emptyRotatedRows = Enumerable.Repeat(n - 1, m).ToArray();

        for (var rotatedRow = n - 1; rotatedRow >= 0; rotatedRow--)
        {
            for (var rotatedColumn = 0; rotatedColumn < m; rotatedColumn++)
            {
                switch (box[m - 1 - rotatedColumn][rotatedRow])
                {
                    case stone:
                        ans[emptyRotatedRows[rotatedColumn]][rotatedColumn] = stone;
                        emptyRotatedRows[rotatedColumn]--;
                        break;
                    case obstacle:
                        ans[rotatedRow][rotatedColumn] = obstacle;
                        emptyRotatedRows[rotatedColumn] = rotatedRow - 1;
                        break;
                }
            }
        }

        return ans;
    }
}
