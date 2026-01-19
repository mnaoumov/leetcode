namespace LeetCode.Problems._3815_Design_Auction_System;

[PublicAPI]
public interface IAuctionSystem
{
    public void AddBid(int userId, int itemId, int bidAmount);
    public void UpdateBid(int userId, int itemId, int newAmount);
    public void RemoveBid(int userId, int itemId);
    public int GetHighestBidder(int itemId);
}
