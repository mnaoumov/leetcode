namespace LeetCode._0158_Read_N_Characters_Given_read4_II___Call_Multiple_Times;

public abstract class Reader4
{
    private string _file = null!;
    private int _index;
    public abstract int Read(char[] buf, int n);

    public void SetFile(string file)
    {
        _file = file;
        _index = 0;
    }

    protected int Read4(char[] buf4)
    {
        var readCount = 0;

        while (readCount < 4)
        {
            if (_index == _file.Length)
            {
                break;
            }

            buf4[readCount] = _file[_index];

            _index++;
            readCount++;
        }

        return readCount;
    }
}