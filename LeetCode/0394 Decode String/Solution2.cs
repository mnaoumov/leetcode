#pragma warning disable CS8618
namespace LeetCode._0394_Decode_String;

/// <summary>
/// https://leetcode.com/submissions/detail/196678531/
/// </summary>
public class Solution2 : ISolution
{
    public string DecodeString(string s)
    {
        var context = new ParsingContext();
        foreach (var symbol in s)
        {
            if (char.IsDigit(symbol))
            {
                context.NestedContext.RepeatCount = 10 * context.NestedContext.RepeatCount + (symbol - '0');
            }
            else if (symbol == '[')
            {
                context = context.NestedContext;
            }
            else if (symbol == ']')
            {
                var parent = context.Parent;
                for (int i = 0; i < context.RepeatCount; i++)
                {
                    parent.Text += context.Text;
                }

                parent.ResetNestedContext();
                context = parent;
            }
            else
            {
                context.Text += symbol;
            }
        }

        return context.Text;
    }

    private class ParsingContext
    {
        public ParsingContext Parent { get; private set; }

        public ParsingContext()
        {
            ResetNestedContext();
        }

        public void ResetNestedContext()
        {
            _lazyNestedContext =
                new Lazy<ParsingContext>(() => new ParsingContext() { Parent = this });
        }

        public int RepeatCount { get; set; }
        public string Text { get; set; } = "";

        public ParsingContext NestedContext => _lazyNestedContext.Value;
        private Lazy<ParsingContext> _lazyNestedContext;
    }
}
