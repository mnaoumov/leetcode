namespace LeetCode.Problems._1352_Product_of_the_Last_K_Numbers;

[PublicAPI]
public interface IProductOfNumbers
{
    void Add(int num);
    int GetProduct(int k);
}
