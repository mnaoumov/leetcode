using JetBrains.Annotations;

namespace LeetCode._1125_Smallest_Sufficient_Team;

[PublicAPI]
public interface ISolution
{
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people);
}
