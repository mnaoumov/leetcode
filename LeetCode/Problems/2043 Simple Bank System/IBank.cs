namespace LeetCode.Problems._2043_Simple_Bank_System;

[PublicAPI]
public interface IBank
{
    public bool Transfer(int account1, int account2, long money);
    public bool Deposit(int account, long money);
    public bool Withdraw(int account, long money);
}
