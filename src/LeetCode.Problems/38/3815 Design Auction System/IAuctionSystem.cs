namespace LeetCode.Problems._3815_Design_Auction_System;

[PublicAPI]
public interface IAuctionSystem
{
    void AddBid(int userId, int itemId, int bidAmount);
    void UpdateBid(int userId, int itemId, int newAmount);
    void RemoveBid(int userId, int itemId);
    int GetHighestBidder(int itemId);
}
