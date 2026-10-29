namespace LeetCode.Problems._2456_Most_Popular_Video_Creator;

[PublicAPI]
public interface ISolution
{
    IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views);
}
