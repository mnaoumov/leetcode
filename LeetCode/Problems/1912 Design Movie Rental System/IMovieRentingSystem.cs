namespace LeetCode.Problems._1912_Design_Movie_Rental_System;

[PublicAPI]
public interface IMovieRentingSystem
{
    public IList<int> Search(int movie);
    public void Rent(int shop, int movie);
    public void Drop(int shop, int movie);
    public IList<IList<int>> Report();
}
