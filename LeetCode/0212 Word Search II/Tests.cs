using JetBrains.Annotations;

namespace LeetCode._0212_Word_Search_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindWords(testCase.Board, testCase.Words), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; private init; } = null!;
        public string[] Words { get; private init; } = null!;
        public IList<string> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'o', 'a', 'a', 'n' }, new[] { 'e', 't', 'a', 'e' }, new[] { 'i', 'h', 'k', 'r' }, new[] { 'i', 'f', 'l', 'v' }
                    },
                    Words = new[] { "oath", "pea", "eat", "rain" },
                    Output = new[] { "eat", "oath" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'a', 'b' }, new[] { 'c', 'd' }
                    },
                    // ReSharper disable once StringLiteralTypo
                    Words = new[] { "abcb" },
                    Output = Array.Empty<string>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'a', 'b', 'c', 'e' }, new[] { 'x', 'x', 'c', 'd' }, new[] { 'x', 'x', 'b', 'a' }
                    },
                    // ReSharper disable once StringLiteralTypo
                    Words = new[] { "abc", "abcd" },
                    // ReSharper disable once StringLiteralTypo
                    Output = new[] { "abc", "abcd" },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        },
                        new[]
                        {
                            'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                            'a', 'a'
                        }
                    },
                    // ReSharper disable once StringLiteralTypo
                    Words = new[]
                    {
                        // ReSharper disable StringLiteralTypo
                        "lllllll", "fffffff", "ssss", "s", "rr", "xxxx", "ttt", "eee", "ppppppp", "iiiiiiiii",
                        "xxxxxxxxxx", "pppppp", "xxxxxx", "yy", "jj", "ccc", "zzz", "ffffffff", "r", "mmmmmmmmm",
                        "tttttttt", "mm", "ttttt", "qqqqqqqqqq", "z", "aaaaaaaa", "nnnnnnnnn", "v", "g", "ddddddd",
                        "eeeeeeeee", "aaaaaaa", "ee", "n", "kkkkkkkkk", "ff", "qq", "vvvvv", "kkkk", "e",
                        "nnn", "ooo", "kkkkk", "o", "ooooooo", "jjj", "lll", "ssssssss", "mmmm", "qqqqq",
                        "gggggg", "rrrrrrrrrr", "iiii", "bbbbbbbbb", "aaaaaa", "hhhh", "qqq", "zzzzzzzzz", "xxxxxxxxx",
                        "ww",
                        "iiiiiii", "pp", "vvvvvvvvvv", "eeeee", "nnnnnnn", "nnnnnn", "nn", "nnnnnnnn", "wwwwwwww",
                        "vvvvvvvv",
                        "fffffffff", "aaa", "p", "ddd", "ppppppppp", "fffff", "aaaaaaaaa", "oooooooo", "jjjj", "xxx",
                        "zz", "hhhhh", "uuuuu", "f", "ddddddddd", "zzzzzz", "cccccc", "kkkkkk", "bbbbbbbb",
                        "hhhhhhhhhh",
                        "uuuuuuu", "cccccccccc", "jjjjj", "gg", "ppp", "ccccccccc", "rrrrrr", "c", "cccccccc", "yyyyy",
                        "uuuu", "jjjjjjjj", "bb", "hhh", "l", "u", "yyyyyy", "vvv", "mmm", "ffffff",
                        "eeeeeee", "qqqqqqq", "zzzzzzzzzz", "ggg", "zzzzzzz", "dddddddddd", "jjjjjjj", "bbbbb",
                        "ttttttt", "dddddddd",
                        "wwwwwww", "vvvvvv", "iii", "ttttttttt", "ggggggg", "xx", "oooooo", "cc", "rrrr", "qqqq",
                        "sssssss", "oooo", "lllllllll", "ii", "tttttttttt", "uuuuuu", "kkkkkkkk", "wwwwwwwwww",
                        "pppppppppp", "uuuuuuuu",
                        "yyyyyyy", "cccc", "ggggg", "ddddd", "llllllllll", "tttt", "pppppppp", "rrrrrrr", "nnnn", "x",
                        "yyy", "iiiiiiiiii", "iiiiii", "llll", "nnnnnnnnnn", "aaaaaaaaaa", "eeeeeeeeee", "m", "uuu",
                        "rrrrrrrr",
                        "h", "b", "vvvvvvv", "ll", "vv", "mmmmmmm", "zzzzz", "uu", "ccccccc", "xxxxxxx",
                        "ss", "eeeeeeee", "llllllll", "eeee", "y", "ppppp", "qqqqqq", "mmmmmm", "gggg", "yyyyyyyyy",
                        "jjjjjj", "rrrrr", "a", "bbbb", "ssssss", "sss", "ooooo", "ffffffffff", "kkk", "xxxxxxxx",
                        "wwwwwwwww", "w", "iiiiiiii", "ffff", "dddddd", "bbbbbb", "uuuuuuuuu", "kkkkkkk", "gggggggggg",
                        "qqqqqqqq",
                        "vvvvvvvvv", "bbbbbbbbbb", "nnnnn", "tt", "wwww", "iiiii", "hhhhhhh", "zzzzzzzz", "ssssssssss",
                        "j",
                        "fff", "bbbbbbb", "aaaa", "mmmmmmmmmm", "jjjjjjjjjj", "sssss", "yyyyyyyy", "hh", "q",
                        "rrrrrrrrr",
                        "mmmmmmmm", "wwwww", "www", "rrr", "lllll", "uuuuuuuuuu", "oo", "jjjjjjjjj", "dddd", "pppp",
                        "hhhhhhhhh", "kk", "gggggggg", "xxxxx", "vvvv", "d", "qqqqqqqqq", "dd", "ggggggggg", "t",
                        "yyyy", "bbb", "yyyyyyyyyy", "tttttt", "ccccc", "aa", "eeeeee", "llllll", "kkkkkkkkkk",
                        "sssssssss",
                        "i", "hhhhhh", "oooooooooo", "wwwwww", "ooooooooo", "zzzz", "k", "hhhhhhhh", "aaaaa", "mmmmm"
                        // ReSharper restore StringLiteralTypo
                    },
                    // ReSharper disable StringLiteralTypo
                    Output = new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" },
                    // ReSharper restore StringLiteralTypo
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
