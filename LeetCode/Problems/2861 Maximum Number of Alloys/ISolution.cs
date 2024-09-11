namespace LeetCode.Problems._2861_Maximum_Number_of_Alloys;

[PublicAPI]
public interface ISolution
{
    public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost);
}
