namespace LeetCode._838_Push_Dominoes;

/// <summary>
/// https://leetcode.com/submissions/detail/809510320/
/// </summary>
public class Solution : ISolution
{
    const char FallingLeft = 'L';
    const char FallingRight = 'R';
    const char Standing = '.';

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
                if (newFalls[i] != default)
                {
                    dominoesArr[i] = newFalls[i];
                }
            }
        }

        return new string(dominoesArr);
    }
}