namespace LeetCode.Problems._0838_Push_Dominoes;

/// <summary>
/// https://leetcode.com/submissions/detail/829086444/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    private const char FallingLeft = 'L';
    private const char FallingRight = 'R';
    private const char Standing = '.';

    public string PushDominoes(string dominoes)
    {
        var dominoesArr = dominoes.ToCharArray();

        while (true)
        {
            var keepsFalling = false;
            var newFalls = new char[dominoesArr.Length];

            for (var i = 0; i < dominoesArr.Length; i++)
            {
                var domino = dominoesArr[i];
                switch (domino)
                {
                    case FallingLeft:
                        if (i > 0 && dominoesArr[i - 1] == Standing && (i == 1 || dominoesArr[i - 2] != FallingRight))
                        {
                            newFalls[i - 1] = FallingLeft;
                            keepsFalling = true;
                        }

                        break;
                    case FallingRight:
                        if (i < dominoesArr.Length - 1 && dominoesArr[i + 1] == Standing &&
                            (i == dominoesArr.Length - 2 || dominoesArr[i + 2] != FallingLeft))
                        {
                            newFalls[i + 1] = FallingRight;
                            keepsFalling = true;
                        }

                        break;
                }
            }

            if (!keepsFalling)
            {
                break;
            }

            for (var i = 0; i < dominoesArr.Length; i++)
            {
                if (newFalls[i] != 0)
                {
                    dominoesArr[i] = newFalls[i];
                }
            }
        }

        return new string(dominoesArr);
    }
}
