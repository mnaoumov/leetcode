namespace LeetCode._0008_String_to_Integer__atoi_;

/// <summary>
/// https://leetcode.com/submissions/detail/807871103/
/// </summary>
public class Solution3 : ISolution
{
    public int MyAtoi(string s)
    {
        var stage = ParsingStage.Start;

        var sign = 1;
        var result = 0;

        for (var index = 0; index < s.Length; index++)
        {
            var symbol = s[index];
            switch (stage)
            {
                case ParsingStage.Start:
                    switch (symbol)
                    {
                        case ' ':
                            continue;
                        case '+':
                            sign = 1;
                            stage = ParsingStage.Sign;
                            break;
                        case '-':
                            sign = -1;
                            stage = ParsingStage.Sign;
                            break;
                        case { } when char.IsDigit(symbol):
                            stage = ParsingStage.Digit;
                            index--;
                            break;
                        default:
                            return 0;
                    }

                    break;
                case ParsingStage.Sign:
                    if (char.IsDigit(symbol))
                    {
                        stage = ParsingStage.Digit;
                        index--;
                    }
                    else
                    {
                        return 0;
                    }
                    break;
                case ParsingStage.Digit:
                    if (char.IsDigit(symbol))
                    {
                        var digit = symbol - '0';
                        const int maxPossibleNumberBeforeAddingLastDigit = int.MaxValue / 10;
                        if (result is > -maxPossibleNumberBeforeAddingLastDigit and < maxPossibleNumberBeforeAddingLastDigit || result == maxPossibleNumberBeforeAddingLastDigit && digit <= 7 || result == -maxPossibleNumberBeforeAddingLastDigit && digit <= 8)
                        {
                            result = 10 * result + digit * sign;
                        }
                        else
                        {
                            return sign == 1 ? int.MaxValue : int.MinValue;
                        }
                    }
                    else
                    {
                        return result;
                    }

                    break;
            }
        }

        return result;
    }

    private enum ParsingStage
    {
        Start,
        Sign,
        Digit
    }
}