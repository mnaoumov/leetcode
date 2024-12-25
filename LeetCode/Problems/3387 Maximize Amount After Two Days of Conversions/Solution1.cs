namespace LeetCode.Problems._3387_Maximize_Amount_After_Two_Days_of_Conversions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-428/submissions/detail/1479041360/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double MaxAmount(string initialCurrency, IList<IList<string>> pairs1, double[] rates1, IList<IList<string>> pairs2, double[] rates2)
    {
        var map1 = GetMap(pairs1, rates1);
        var map2 = GetMap(pairs2, rates2);

        const string noCurrency = "";
        var queue1 = new Queue<(string previousCurrency, string currency, double amount)>();
        var queue2 = new Queue<(string previousCurrency, string currency, double amount)>();
        queue1.Enqueue((noCurrency, initialCurrency, 1d));

        while (queue1.Count > 0)
        {
            var (previousCurrency, currency, amount) = queue1.Dequeue();

            queue2.Enqueue((noCurrency, currency, amount));

            if (!map1.TryGetValue(currency, out var exchanges1))
            {
                continue;
            }

            foreach (var exchange in exchanges1.Where(exchange => exchange.To != previousCurrency))
            {
                queue1.Enqueue((currency, exchange.To, amount * exchange.Rate));
            }
        }

        var ans = 1d;

        while (queue2.Count > 0)
        {
            var (previousCurrency, currency, amount) = queue2.Dequeue();

            if (currency == initialCurrency)
            {
                ans = Math.Max(ans, amount);
                continue;
            }

            if (!map2.TryGetValue(currency, out var exchanges2))
            {
                continue;
            }

            foreach (var exchange in exchanges2.Where(exchange => exchange.To != previousCurrency))
            {
                queue2.Enqueue((currency, exchange.To, amount * exchange.Rate));
            }
        }

        return ans;
    }

    private static Dictionary<string, List<CurrencyExchange>> GetMap(
        IList<IList<string>> fromToCurrencyPairs, double[] rates)
    {
        var n = fromToCurrencyPairs.Count;
        var ans = new Dictionary<string, List<CurrencyExchange>>();

        for (var i = 0; i < n; i++)
        {
            var from = fromToCurrencyPairs[i][0];
            var to = fromToCurrencyPairs[i][1];
            var rate = rates[i];

            ans.TryAdd(from, new List<CurrencyExchange>());
            ans.TryAdd(to, new List<CurrencyExchange>());

            ans[from].Add(new CurrencyExchange(from, to, rate));
            ans[to].Add(new CurrencyExchange(to, from, 1 / rate));
        }

        return ans;
    }

    private record CurrencyExchange(string From, string To, double Rate);
}
