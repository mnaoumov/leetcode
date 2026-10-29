namespace LeetCode.Problems._3709_Design_Exam_Scores_Tracker;

[PublicAPI]
public interface IExamTracker
{
    void Record(int time, int score);
    long TotalScore(int startTime, int endTime);
}
