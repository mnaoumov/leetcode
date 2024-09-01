using JetBrains.Annotations;

namespace LeetCode.Problems._3273_Minimum_Amount_of_Damage_Dealt_to_Bob;

[PublicAPI]
public interface ISolution
{
    public long MinDamage(int power, int[] damage, int[] health);
}
