using System.Text;

namespace LeetCode._838_Push_Dominoes;

public class Solution : ISolution
{
    const char FallingLeft = 'L';
    const char FallingRight = 'R';
    const char Standing = '.';

    public string PushDominoes(string dominoes)
    {
        var dominoesArr = dominoes.ToCharArray();

        bool keepsFalling;
        do
        {
            keepsFalling = false;

            for (var i = 0; i < dominoesArr.Length; i++)
            {
                var domino = dominoesArr[i];
                switch (domino)
                {
                    case FallingLeft:
                        if (i > 0 && dominoesArr[i - 1] == Standing && (i == 1 || dominoesArr[i - 2] != FallingRight))
                        {
                            dominoesArr[i - 1] = FallingLeft;
                            keepsFalling = true;
                        }

                        break;
                    case FallingRight:
                        if (i < dominoesArr.Length - 1 && dominoesArr[i + 1] == Standing &&
                            (i == dominoesArr.Length - 2 || dominoesArr[i + 2] != FallingLeft))
                        {
                            dominoesArr[i + 1] = FallingRight;
                            keepsFalling = true;
                        }

                        break;
                }
            }
        } while (keepsFalling);

        return new string(dominoesArr);
    }
}