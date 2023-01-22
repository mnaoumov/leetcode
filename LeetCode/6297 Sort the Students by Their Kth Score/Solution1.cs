using JetBrains.Annotations;

namespace LeetCode._6297_Sort_the_Students_by_Their_Kth_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-329/submissions/detail/882773714/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] SortTheStudents(int[][] score, int k) => score.OrderByDescending(studentScores => studentScores[k]).ToArray();
}
