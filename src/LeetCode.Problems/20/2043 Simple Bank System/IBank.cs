namespace LeetCode.Problems._2043_Simple_Bank_System;

[PublicAPI]
public interface IBank
{
    bool Transfer(int account1, int account2, long money);
    bool Deposit(int account, long money);
    bool Withdraw(int account, long money);
}
