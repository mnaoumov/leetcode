namespace LeetCode.Problems._1236_Web_Crawler;

[PublicAPI]
public interface ISolution
{
    IList<string> Crawl(string startUrl, HtmlParser htmlParser);
}
