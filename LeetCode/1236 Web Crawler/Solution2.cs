using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace LeetCode._1236_Web_Crawler;

/// <summary>
/// https://leetcode.com/submissions/detail/919843175/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
    {
        var host = Host(startUrl);
        var result = new List<string>();
        var queue = new Queue<string>();
        var seen = new HashSet<string>();

        queue.Enqueue(startUrl);

        while (queue.Count > 0)
        {
            var url = queue.Dequeue();

            if (!seen.Add(url))
            {
                continue;
            }

            if (Host(url) != host)
            {
                continue;
            }

            result.Add(url);

            foreach (var nextUrl in htmlParser.GetUrls(url))
            {
                queue.Enqueue(nextUrl);
            }
        }

        return result;
    }

    private static string Host(string url) => Regex.Match(url, "http://(?<Host>.+?)(/|$)").Groups["Host"].Value;
}