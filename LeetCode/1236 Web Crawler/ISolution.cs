using JetBrains.Annotations;

namespace LeetCode._1236_Web_Crawler;

[PublicAPI]
public interface ISolution
{
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser);
}
