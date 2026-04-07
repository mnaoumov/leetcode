namespace LeetCode.Problems._0379_Design_Phone_Directory;
#pragma warning disable CA1716

[PublicAPI]
public interface IPhoneDirectory
{
    int Get();
    bool Check(int number);
    void Release(int number);
}
