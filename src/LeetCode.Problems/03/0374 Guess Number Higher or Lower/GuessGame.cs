namespace LeetCode.Problems._0374_Guess_Number_Higher_or_Lower;

public abstract class GuessGame
{
    private int _pick;

#pragma warning disable IDE1006 // Naming Styles
    // ReSharper disable once InconsistentNaming
    protected int guess(int num) => _pick.CompareTo(num);
#pragma warning restore IDE1006 // Naming Styles

    public void SetPick(int pick) => _pick = pick;

    public abstract int GuessNumber(int n);
}
