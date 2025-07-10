namespace LeetCode.Problems._3606_Coupon_Code_Validator;

[PublicAPI]
public interface ISolution
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive);
}
