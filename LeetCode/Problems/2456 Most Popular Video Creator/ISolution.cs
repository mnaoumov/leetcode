using JetBrains.Annotations;

namespace LeetCode.Problems._2456_Most_Popular_Video_Creator;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views);
}
