﻿namespace LeetCode.Problem008_StringToIntegerAtoi
{
    public class Solution : ISolution
    {
        public int MyAtoi(string str)
        {
            var result = 0;
            bool hasSign = false;
            bool isPositiveSign = true;
            bool onlyWhiteSpace = true;

            foreach (var symbol in str)
            {
                if (char.IsDigit(symbol))
                {
                    onlyWhiteSpace = false;
                    int digit = symbol - '0';
                    if (result > int.MaxValue / 10)
                        return int.MaxValue;
                    if (result < int.MinValue / 10)
                        return int.MinValue;
                    result = result * 10;

                    if (result > int.MaxValue - digit)
                        return int.MaxValue;
                    if (result < int.MinValue + digit)
                        return int.MinValue;

                    if (result < 0 || !isPositiveSign)
                        result = result - digit;
                    else
                        result = result + digit;
                }
                else if (symbol == '+' && !hasSign)
                {
                    hasSign = true;
                    onlyWhiteSpace = false;
                }
                else if (symbol == '-' && !hasSign)
                {
                    hasSign = true;
                    isPositiveSign = false;
                    onlyWhiteSpace = false;
                }
                else if (char.IsWhiteSpace(symbol) && onlyWhiteSpace)
                    continue;
                else
                    return result;
            }

            return result;
        }
    }
}