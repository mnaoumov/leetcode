namespace LeetCode._0374_Guess_Number_Higher_or_Lower;

public abstract class GuessGame
{
    private int _pick;

    // ReSharper disable once InconsistentNaming
    public int guess(int num) => _pick.CompareTo(num);

    public void SetPick(int pick) => _pick = pick;

    public abstract int GuessNumber(int n);
}