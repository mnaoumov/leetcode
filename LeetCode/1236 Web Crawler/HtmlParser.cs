namespace LeetCode._1236_Web_Crawler;

public class HtmlParser
{
    private readonly Dictionary<string, List<string>> _urlsMap = new();

    public HtmlParser(IReadOnlyList<string> urls, IEnumerable<int[]> edges)
    {
        foreach (var edge in edges)
        {
            if (edge[0] < 0 || edge[1] < 0 || edge[0] >= urls.Count || edge[1] >= urls.Count)
            {
                continue;
            }

            var from = urls[edge[0]];
            var to = urls[edge[1]];
            if (!_urlsMap.ContainsKey(from))
            {
                _urlsMap[from] = new List<string>();
            }

            _urlsMap[from].Add(to);
        }
    }

    public List<string> GetUrls(string url) => _urlsMap.GetValueOrDefault(url, new List<string>());
}
