using JetBrains.Annotations;

namespace LeetCode.Problems._2024_Maximize_the_Confusion_of_an_Exam;

[PublicAPI]
public interface ISolution
{
    public int MaxConsecutiveAnswers(string answerKey, int k);
}
