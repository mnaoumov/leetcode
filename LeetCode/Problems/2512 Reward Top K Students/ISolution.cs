namespace LeetCode.Problems._2512_Reward_Top_K_Students;

[PublicAPI]
public interface ISolution
{
    // ReSharper disable InconsistentNaming
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k);
    // ReSharper restore InconsistentNaming
}
