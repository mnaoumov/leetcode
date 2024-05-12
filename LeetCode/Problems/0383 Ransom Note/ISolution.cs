using JetBrains.Annotations;

namespace LeetCode._0383_Ransom_Note;

[PublicAPI]
public interface ISolution
{
    public bool CanConstruct(string ransomNote, string magazine);
}
