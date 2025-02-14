using System.Numerics;

namespace LeetCode.Problems._1352_Product_of_the_Last_K_Numbers;

/// <summary>
/// https://leetcode.com/problems/product-of-the-last-k-numbers/submissions/1542334466/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IProductOfNumbers Create() => new ProductOfNumbers();

    private class ProductOfNumbers : IProductOfNumbers
    {
        private readonly List<(BigInteger nonZeroProduct, int zerosCount)> _prefixProducts = new();

        public ProductOfNumbers() => _prefixProducts.Add((1, 0));

        public void Add(int num)
        {
            var lastPair = _prefixProducts[^1];

            _prefixProducts.Add(num > 0
                ? (lastPair.nonZeroProduct * num, lastPair.zerosCount)
                : (lastPair.nonZeroProduct, lastPair.zerosCount + 1)
            );
        }
    
        public int GetProduct(int k)
        {
            var lastPair = _prefixProducts[^1];
            var beforeFirstPair = _prefixProducts[^(k + 1)];
            if (lastPair.zerosCount - beforeFirstPair.zerosCount > 0)
            {
                return 0;
            }

            return (int) (lastPair.nonZeroProduct / beforeFirstPair.nonZeroProduct);
        }
    }
}
