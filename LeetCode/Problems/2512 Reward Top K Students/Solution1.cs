using JetBrains.Annotations;

namespace LeetCode.Problems._2512_Reward_Top_K_Students;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-94/submissions/detail/864788321/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable InconsistentNaming
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
    // ReSharper restore InconsistentNaming
    {
        var positiveFeedbackWords = positive_feedback.ToHashSet();
        var negativeFeedbackWords = negative_feedback.ToHashSet();

        var topStudentIndices = new PriorityQueue<int, (int points, int negativeStudentId)>();

        for (var i = 0; i < report.Length; i++)
        {
            var points = 0;
            var feedbackWords = report[i].Split(' ');

            foreach (var feedbackWord in feedbackWords)
            {
                if (positiveFeedbackWords.Contains(feedbackWord))
                {
                    points += 3;
                }

                if (negativeFeedbackWords.Contains(feedbackWord))
                {
                    points--;
                }
            }

            topStudentIndices.Enqueue(student_id[i], (points, -student_id[i]));

            if (topStudentIndices.Count > k)
            {
                topStudentIndices.Dequeue();
            }
        }

        var result = new List<int>();

        while (topStudentIndices.Count > 0)
        {
            result.Insert(0, topStudentIndices.Dequeue());
        }

        return result;
    }
}
