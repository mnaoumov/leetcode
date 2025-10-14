namespace LeetCode.Problems._3709_Design_Exam_Scores_Tracker;

[PublicAPI]
public interface IExamTracker
{
    public void Record(int time, int score);
    public long TotalScore(int startTime, int endTime);
}
