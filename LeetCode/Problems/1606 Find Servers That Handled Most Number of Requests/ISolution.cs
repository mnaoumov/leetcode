using JetBrains.Annotations;

namespace LeetCode._1606_Find_Servers_That_Handled_Most_Number_of_Requests;

[PublicAPI]
public interface ISolution
{
    public IList<int> BusiestServers(int k, int[] arrival, int[] load);
}
