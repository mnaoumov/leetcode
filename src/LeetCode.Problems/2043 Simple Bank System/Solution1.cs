namespace LeetCode.Problems._2043_Simple_Bank_System;

/// <summary>
/// https://leetcode.com/problems/simple-bank-system/submissions/1811689608/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IBank Create(long[] balance) => new Bank(balance);

    private class Bank : IBank
    {
        private readonly long[] _balance;

        public Bank(long[] balance) => _balance = balance;

        public bool Transfer(int account1, int account2, long money)
        {
            var n = _balance.Length;

            if (account1 < 1 || account2 < 1 || account1 > n || account2 > n)
            {
                return false;
            }

            if (_balance[account1 - 1] < money)
            {
                return false;
            }

            _balance[account1 - 1] -= money;
            _balance[account2 - 1] += money;
            return true;
        }

        public bool Deposit(int account, long money)
        {
            var n = _balance.Length;

            if (account < 1 || account > n)
            {
                return false;
            }

            _balance[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            var n = _balance.Length;

            if (account < 1 || account > n)
            {
                return false;
            }

            if (_balance[account - 1] < money)
            {
                return false;
            }

            _balance[account - 1] -= money;
            return true;
        }
    }
}
