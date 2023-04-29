using JetBrains.Annotations;

namespace LeetCode._1538_Guess_the_Majority_in_a_Hidden_Array;

[PublicAPI]
public interface ISolution
{
    public int GuessMajority(ArrayReader reader);
}