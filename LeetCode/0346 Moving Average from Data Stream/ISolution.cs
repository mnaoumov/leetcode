using JetBrains.Annotations;

namespace LeetCode._0346_Moving_Average_from_Data_Stream;

[PublicAPI]
public interface ISolution
{
    public IMovingAverage Create(int size);
}
