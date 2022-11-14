using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6236_Maximum_Number_of_Non_overlapping_Palindrome_Substrings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPalindromes(testCase.S, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "abaccdbbd",
                    K = 3,
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "adbcda",
                    K = 2,
                    Output = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "fojnrcnerybjjghhaykxykixkojokxikyxkyahhgjjbyrencrnjofzyzeftizdmiynofcwlwcfonyimdzitfezyzqywfmxqcqhwbsmtbfberkuiukrebfbtmsbwhqcqxmfwywhoppuqnxqesiqedlpujohqpnvzvljyjlvzvnpqhojupldeqiseqxnquppohwrniimkadiwfkesjhhjsekfwidakmiingbsasadxeqxacdhxqkupyprzrcjaqtqajcrzrpypukqxhdcaxqexdasawuumyhklbhodwcmydtkfezcuesnjjnseuczefktdymcwdohblkhymuuwsdquovgnrckcpubplmueyaernzdmcmdznreayeumlpbupckcrngvouqdpsktcrqynclzrgjtplokkfihhymmgsgmmyhhifkkolptjgrzlcnyqrctksvnchfxupvsyljxzadjhohjdazxjlysvpuxfhcnwatcqotbwunztyzryjmmjyrzytznuwbtoqctawdykmoeebpeqmgbdexfwxcelvwxyrryxwvlecxwfxedbgmqepbeeblxevnmdcnrwfsaqqasfwrncdmnvexlbwaurakgpqtjpymaibpebeqlelqebepbiamypjtqpgkaruawceerqumnqbdwnbtlcootttibpdjpckqfcrmajjamrcfqkcpjdpbitttoocltbnwdbqnmuqreeyvfwueuewqyxyiaquqaiyxyqweueuwfvksskyuswbeqpihumbedwoxhufidbdifuhxowdebmuhipqebwsuykssktegrvozxyiofngmqbkiqfagxsfyllzgumemugzllyfsxgafqikbqmgnfoiyxzosthtycrjroeipdirvtrlzukccpqpcckuzlrtvridpieorjrcythtsdalhtjojbryxaoxppdxpwwbbklywnamrxtjpwtqfxyegmywwvwwymgeyxfqtwpjtxrmanwylkbbwwpxdppxoabymjvqlwqnmfzerregerrezfmnqwlqvjmybgogqdfigragpafjcyfzkqxzladjqufrrfuqjdalzxqkzfycjfapgargifdqgogarlptpazebeudrmymnvimxkssysytgujznjancjrjcnajnzjugtysysskxmivnmymrduebezaptphpmeblrzbxzzvxpwwxhiykxmbdcrwvcketekcvwrcdbmxkyihxwwpxvzzxbzrlbemhvcaswtkxbsdpalkxkddqokerskptsustbcbtsustpksrekoqddkxklapdsbxktwsacvhmjigkwrygxusxbbguwzngqoqbknehaopuvvupoahenkbqoqgnzwugbbxsuxgyrwkgikjureyadreoxreinabllbanierxoerdayerujkmjuxcoydsukgdctdcnrsqxcrzvmxmvzrcxqsrncdtcdgkusdyocxuuznoynsubjvoibuxfddwfogofwddfxubiovjbusnyonzuuubdw",
                    K = 24,
                    Output = 29,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "iqqibcecvrbxxj",
                    K = 1,
                    Output = 14,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
