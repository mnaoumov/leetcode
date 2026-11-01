namespace LeetCode.Problems._2545_Sort_the_Students_by_Their_Kth_Score;

/// <seealso href="https://leetcode.com/contest/weekly-contest-329/submissions/detail/882773714/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] SortTheStudents(int[][] score, int k) => score.OrderByDescending(studentScores => studentScores[k]).ToArray();
}
