namespace LeetCode.Problems._1912_Design_Movie_Rental_System;

[PublicAPI]
public interface IMovieRentingSystem
{
    IList<int> Search(int movie);
    void Rent(int shop, int movie);
    void Drop(int shop, int movie);
    IList<IList<int>> Report();
}
