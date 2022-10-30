using JetBrains.Annotations;

namespace LeetCode._6221_Most_Popular_Video_Creator;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views);
}
