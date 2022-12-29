using JetBrains.Annotations;

namespace LeetCode._2512_Reward_Top_K_Students;

[PublicAPI]
public interface ISolution
{
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k);
}
