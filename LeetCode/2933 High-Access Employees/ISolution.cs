using JetBrains.Annotations;

namespace LeetCode._2933_High_Access_Employees;

[PublicAPI]
public interface ISolution
{
    public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times);
}
