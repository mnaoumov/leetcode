using JetBrains.Annotations;

namespace LeetCode._2933_High_Access_Employees;

[PublicAPI]
public interface ISolution
{
    // ReSharper disable once InconsistentNaming
    public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times);
}
