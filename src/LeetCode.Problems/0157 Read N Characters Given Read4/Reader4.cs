namespace LeetCode.Problems._0157_Read_N_Characters_Given_Read4;

public abstract class Reader4
{
    private string _file = null!;
    private int _position;

    protected int Read4(char[] buf4)
    {
        for (var i = 0; i < 4; i++)
        {
            if (_position >= _file.Length)
            {
                return i;
            }

            buf4[i] = _file[_position];
            _position++;
        }

        return 4;
    }

    public abstract int Read(char[] buf, int n);

    public void SetFile(string file)
    {
        _file = file;
        _position = 0;
    }
}
