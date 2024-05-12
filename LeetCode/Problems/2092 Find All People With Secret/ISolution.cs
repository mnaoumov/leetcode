using JetBrains.Annotations;

namespace LeetCode.Problems._2092_Find_All_People_With_Secret;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson);
}
