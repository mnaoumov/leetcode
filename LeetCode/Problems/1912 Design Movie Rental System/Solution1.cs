namespace LeetCode.Problems._1912_Design_Movie_Rental_System;

/// <summary>
/// https://leetcode.com/problems/design-movie-rental-system/submissions/1778285363/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IMovieRentingSystem Create(int n, int[][] entries) => new MovieRentingSystem(n, entries);

    private class MovieRentingSystem : IMovieRentingSystem
    {
        private readonly Dictionary<int, PriorityQueue<int, (int price, int shop)>> _movieQueueMap = new();
        private readonly HashSet<(int shop, int movie)> _unrentedMovies = new();
        private readonly Dictionary<(int shop, int movie), int> _prices = new();
        private readonly PriorityQueue<(int shop, int movie), (int price, int shop, int movie)> _cheapestRentedQueue = new();

        public MovieRentingSystem(int n, int[][] entries)
        {
            foreach (var entry in entries)
            {
                var shop = entry[0];
                var movie = entry[1];
                var price = entry[2];

                _movieQueueMap.TryAdd(movie, new PriorityQueue<int, (int price, int shop)>());
                _movieQueueMap[movie].Enqueue(shop, (price, shop));
                _unrentedMovies.Add((shop, movie));
                _prices[(shop, movie)] = price;
            }
        }

        public IList<int> Search(int movie)
        {
            var queue = _movieQueueMap.GetValueOrDefault(movie, new PriorityQueue<int, (int price, int shop)>());
            var ans = new List<int>();

            while (queue.Count > 0)
            {
                var shop = queue.Dequeue();

                if (!_unrentedMovies.Contains((shop, movie)))
                {
                    continue;
                }

                ans.Add(shop);

                if (ans.Count == 5)
                {
                    break;
                }
            }

            foreach (var shop in ans)
            {
                queue.Enqueue(shop, (_prices[(shop, movie)], shop));
            }

            return ans;
        }

        public void Rent(int shop, int movie)
        {
            _unrentedMovies.Remove((shop, movie));
            _cheapestRentedQueue.Enqueue((shop, movie), (_prices[(shop, movie)], shop, movie));
        }

        public void Drop(int shop, int movie)
        {
            _unrentedMovies.Add((shop, movie));
        }

        public IList<IList<int>> Report()
        {
            var ans = new List<IList<int>>();

            while (_cheapestRentedQueue.Count > 0)
            {
                var (shop, movie) = _cheapestRentedQueue.Dequeue();

                if (_unrentedMovies.Contains((shop, movie)))
                {
                    continue;
                }

                ans.Add(new[] { shop, movie });

                if (ans.Count == 5)
                {
                    break;
                }
            }
            return ans;
        }
    }
}
