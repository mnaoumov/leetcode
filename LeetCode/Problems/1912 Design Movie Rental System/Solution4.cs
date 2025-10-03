namespace LeetCode.Problems._1912_Design_Movie_Rental_System;

/// <summary>
/// https://leetcode.com/problems/design-movie-rental-system/submissions/1778375114/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public IMovieRentingSystem Create(int n, int[][] entries) => new MovieRentingSystem(n, entries);

    private class MovieRentingSystem : IMovieRentingSystem
    {
        private readonly Dictionary<int, SortedSet<Entry>> _unrentedMovieGroups = new();
        private readonly Dictionary<ShopMovie, int> _prices = new();
        private readonly SortedSet<Entry> _cheapestRentedQueue = new();

        // ReSharper disable once UnusedParameter.Local
        public MovieRentingSystem(int n, int[][] entries)
        {
            foreach (var entry in entries)
            {
                var shop = entry[0];
                var movie = entry[1];
                var price = entry[2];

                _unrentedMovieGroups.TryAdd(movie, new SortedSet<Entry>());
                _unrentedMovieGroups[movie].Add(new Entry(price, shop, movie));
                _prices[new ShopMovie(shop, movie)] = price;
            }
        }

        public IList<int> Search(int movie)
        {
            var set = _unrentedMovieGroups.GetValueOrDefault(movie, new SortedSet<Entry>());
            var ans = new List<int>();

            foreach (var entry in set)
            {
                ans.Add(entry.Shop);

                if (ans.Count == 5)
                {
                    break;
                }
            }

            return ans;
        }

        private Entry ToEntry(ShopMovie shopMovie) => new(_prices[shopMovie], shopMovie.Shop, shopMovie.Movie);

        public void Rent(int shop, int movie)
        {
            var shopMovie = new ShopMovie(shop, movie);
            var entry = ToEntry(shopMovie);

            _cheapestRentedQueue.Add(entry);
            var set = _unrentedMovieGroups.GetValueOrDefault(movie, new SortedSet<Entry>());
            set.Remove(entry);
        }

        public void Drop(int shop, int movie)
        {
            var shopMovie = new ShopMovie(shop, movie);
            var entry = ToEntry(shopMovie);

            _cheapestRentedQueue.Remove(entry);
            var set = _unrentedMovieGroups.GetValueOrDefault(movie, new SortedSet<Entry>());
            set.Add(entry);
        }

        public IList<IList<int>> Report()
        {
            var ans = new List<IList<int>>();

            foreach (var entry in _cheapestRentedQueue)
            {
                ans.Add(new[] { entry.Shop, entry.Movie });

                if (ans.Count == 5)
                {
                    break;
                }
            }

            return ans;
        }

        private record ShopMovie(int Shop, int Movie);
        // ReSharper disable once NotAccessedPositionalProperty.Local
        private record Entry(int Price, int Shop, int Movie): IComparable<Entry>
        {
            public int CompareTo(Entry? other)
            {
                if (other == null)
                {
                    return 1;
                }
                return (Price, Shop, Movie).CompareTo((other.Price, other.Shop, other.Movie));
            }
        }
    }
}
