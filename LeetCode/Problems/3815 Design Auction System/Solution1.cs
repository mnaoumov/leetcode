namespace LeetCode.Problems._3815_Design_Auction_System;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-485/problems/design-auction-system/submissions/1888493009/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IAuctionSystem Create() => new AuctionSystem();

    private class AuctionSystem : IAuctionSystem
    {
        private readonly Dictionary<(int itemId, int userId), int> _bids = new();
        private readonly Dictionary<int, SortedSet<(int inverseBid, int userId)>> _itemIdSortedBids = new();

        public void AddBid(int userId, int itemId, int bidAmount)
        {
            var key = (itemId, userId);

            if (_bids.TryGetValue(key, out var bid))
            {
                _itemIdSortedBids[itemId].Remove((-bid, userId));
            }

            _bids[key] = bidAmount;
            _itemIdSortedBids.TryAdd(itemId, new SortedSet<(int inverseBid, int userId)>());
            _itemIdSortedBids[itemId].Add((-bidAmount, userId));
        }

        public void UpdateBid(int userId, int itemId, int newAmount)
        {
            AddBid(userId, itemId, newAmount);
        }

        public void RemoveBid(int userId, int itemId)
        {
            var key = (itemId, userId);
            var bid = _bids[key];
            _itemIdSortedBids[itemId].Remove((-bid, userId));
            _bids.Remove(key);
        }

        public int GetHighestBidder(int itemId) =>
            _itemIdSortedBids.TryGetValue(itemId, out var set) ? set.Min.userId : -1;
    }
}
