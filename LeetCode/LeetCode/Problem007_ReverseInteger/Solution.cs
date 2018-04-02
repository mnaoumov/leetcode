using System;

namespace LeetCode.Problem007_ReverseInteger
{
    public class Solution : ISolution
    {
        public int Reverse(int x)
        {
            var sign = Math.Sign(x);
            x = Math.Abs(x);
            var result = 0;
            while (x > 0)
            {
                var lastDigit = x % 10;
                result = result * 10 + lastDigit;
                x = x / 10;
            }

            result = result * sign;

            return result;
        }
    }
}