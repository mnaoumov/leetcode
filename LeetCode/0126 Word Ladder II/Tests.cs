using JetBrains.Annotations;

namespace LeetCode._0126_Word_Ladder_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindLadders(testCase.BeginWord, testCase.EndWord, testCase.WordList), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string BeginWord { get; private init; } = null!;
        public string EndWord { get; private init; } = null!;
        public IList<string> WordList { get; private init; } = null!;
        public IList<IList<string>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    BeginWord = "hit",
                    EndWord = "cog",
                    WordList = new[] { "hot", "dot", "dog", "lot", "log", "cog" },
                    Output = new IList<string>[]
                    {
                        new[] { "hit", "hot", "dot", "dog", "cog" }, new[] { "hit", "hot", "lot", "log", "cog" }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    BeginWord = "hit",
                    EndWord = "cog",
                    WordList = new[] { "hot", "dot", "dog", "lot", "log" },
                    Output = Array.Empty<IList<string>>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    BeginWord = "red",
                    EndWord = "tax",
                    WordList = new[] { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" },
                    Output = new IList<string>[]
                    {
                        new[] { "red", "ted", "tad", "tax" },
                        new[] { "red", "ted", "tex", "tax" },
                        new[] { "red", "rex", "tex", "tax" }
                    },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    BeginWord = "aaaaa",
                    // ReSharper disable once StringLiteralTypo
                    EndWord = "ggggg",
                    WordList = new[]
                    {
                        // ReSharper disable StringLiteralTypo
                        "aaaaa", "caaaa", "cbaaa", "daaaa", "dbaaa", "eaaaa", "ebaaa", "faaaa", "fbaaa", "gaaaa",
                        "gbaaa", "haaaa", "hbaaa", "iaaaa", "ibaaa", "jaaaa", "jbaaa", "kaaaa", "kbaaa", "laaaa",
                        "lbaaa", "maaaa", "mbaaa", "naaaa", "nbaaa", "oaaaa", "obaaa", "paaaa", "pbaaa", "bbaaa",
                        "bbcaa", "bbcba", "bbdaa", "bbdba", "bbeaa", "bbeba", "bbfaa", "bbfba", "bbgaa", "bbgba",
                        "bbhaa", "bbhba", "bbiaa", "bbiba", "bbjaa", "bbjba", "bbkaa", "bbkba", "bblaa", "bblba",
                        "bbmaa", "bbmba", "bbnaa", "bbnba", "bboaa", "bboba", "bbpaa", "bbpba", "bbbba", "abbba",
                        "acbba", "dbbba", "dcbba", "ebbba", "ecbba", "fbbba", "fcbba", "gbbba", "gcbba", "hbbba",
                        "hcbba", "ibbba", "icbba", "jbbba", "jcbba", "kbbba", "kcbba", "lbbba", "lcbba", "mbbba",
                        "mcbba", "nbbba", "ncbba", "obbba", "ocbba", "pbbba", "pcbba", "ccbba", "ccaba", "ccaca",
                        "ccdba", "ccdca", "cceba", "cceca", "ccfba", "ccfca", "ccgba", "ccgca", "cchba", "cchca",
                        "cciba", "ccica", "ccjba", "ccjca", "cckba", "cckca", "cclba", "cclca", "ccmba", "ccmca",
                        "ccnba", "ccnca", "ccoba", "ccoca", "ccpba", "ccpca", "cccca", "accca", "adcca", "bccca",
                        "bdcca", "eccca", "edcca", "fccca", "fdcca", "gccca", "gdcca", "hccca", "hdcca", "iccca",
                        "idcca", "jccca", "jdcca", "kccca", "kdcca", "lccca", "ldcca", "mccca", "mdcca", "nccca",
                        "ndcca", "occca", "odcca", "pccca", "pdcca", "ddcca", "ddaca", "ddada", "ddbca", "ddbda",
                        "ddeca", "ddeda", "ddfca", "ddfda", "ddgca", "ddgda", "ddhca", "ddhda", "ddica", "ddida",
                        "ddjca", "ddjda", "ddkca", "ddkda", "ddlca", "ddlda", "ddmca", "ddmda", "ddnca", "ddnda",
                        "ddoca", "ddoda", "ddpca", "ddpda", "dddda", "addda", "aedda", "bddda", "bedda", "cddda",
                        "cedda", "fddda", "fedda", "gddda", "gedda", "hddda", "hedda", "iddda", "iedda", "jddda",
                        "jedda", "kddda", "kedda", "lddda", "ledda", "mddda", "medda", "nddda", "nedda", "oddda",
                        "oedda", "pddda", "pedda", "eedda", "eeada", "eeaea", "eebda", "eebea", "eecda", "eecea",
                        "eefda", "eefea", "eegda", "eegea", "eehda", "eehea", "eeida", "eeiea", "eejda", "eejea",
                        "eekda", "eekea", "eelda", "eelea", "eemda", "eemea", "eenda", "eenea", "eeoda", "eeoea",
                        "eepda", "eepea", "eeeea", "ggggg", "agggg", "ahggg", "bgggg", "bhggg", "cgggg", "chggg",
                        "dgggg", "dhggg", "egggg", "ehggg", "fgggg", "fhggg", "igggg", "ihggg", "jgggg", "jhggg",
                        "kgggg", "khggg", "lgggg", "lhggg", "mgggg", "mhggg", "ngggg", "nhggg", "ogggg", "ohggg",
                        "pgggg", "phggg", "hhggg", "hhagg", "hhahg", "hhbgg", "hhbhg", "hhcgg", "hhchg", "hhdgg",
                        "hhdhg", "hhegg", "hhehg", "hhfgg", "hhfhg", "hhigg", "hhihg", "hhjgg", "hhjhg", "hhkgg",
                        "hhkhg", "hhlgg", "hhlhg", "hhmgg", "hhmhg", "hhngg", "hhnhg", "hhogg", "hhohg", "hhpgg",
                        "hhphg", "hhhhg", "ahhhg", "aihhg", "bhhhg", "bihhg", "chhhg", "cihhg", "dhhhg", "dihhg",
                        "ehhhg", "eihhg", "fhhhg", "fihhg", "ghhhg", "gihhg", "jhhhg", "jihhg", "khhhg", "kihhg",
                        "lhhhg", "lihhg", "mhhhg", "mihhg", "nhhhg", "nihhg", "ohhhg", "oihhg", "phhhg", "pihhg",
                        "iihhg", "iiahg", "iiaig", "iibhg", "iibig", "iichg", "iicig", "iidhg", "iidig", "iiehg",
                        "iieig", "iifhg", "iifig", "iighg", "iigig", "iijhg", "iijig", "iikhg", "iikig", "iilhg",
                        "iilig", "iimhg", "iimig", "iinhg", "iinig", "iiohg", "iioig", "iiphg", "iipig", "iiiig",
                        "aiiig", "ajiig", "biiig", "bjiig", "ciiig", "cjiig", "diiig", "djiig", "eiiig", "ejiig",
                        "fiiig", "fjiig", "giiig", "gjiig", "hiiig", "hjiig", "kiiig", "kjiig", "liiig", "ljiig",
                        "miiig", "mjiig", "niiig", "njiig", "oiiig", "ojiig", "piiig", "pjiig", "jjiig", "jjaig",
                        "jjajg", "jjbig", "jjbjg", "jjcig", "jjcjg", "jjdig", "jjdjg", "jjeig", "jjejg", "jjfig",
                        "jjfjg", "jjgig", "jjgjg", "jjhig", "jjhjg", "jjkig", "jjkjg", "jjlig", "jjljg", "jjmig",
                        "jjmjg", "jjnig", "jjnjg", "jjoig", "jjojg", "jjpig", "jjpjg", "jjjjg", "ajjjg", "akjjg",
                        "bjjjg", "bkjjg", "cjjjg", "ckjjg", "djjjg", "dkjjg", "ejjjg", "ekjjg", "fjjjg", "fkjjg",
                        "gjjjg", "gkjjg", "hjjjg", "hkjjg", "ijjjg", "ikjjg", "ljjjg", "lkjjg", "mjjjg", "mkjjg",
                        "njjjg", "nkjjg", "ojjjg", "okjjg", "pjjjg", "pkjjg", "kkjjg", "kkajg", "kkakg", "kkbjg",
                        "kkbkg", "kkcjg", "kkckg", "kkdjg", "kkdkg", "kkejg", "kkekg", "kkfjg", "kkfkg", "kkgjg",
                        "kkgkg", "kkhjg", "kkhkg", "kkijg", "kkikg", "kkljg", "kklkg", "kkmjg", "kkmkg", "kknjg",
                        "kknkg", "kkojg", "kkokg", "kkpjg", "kkpkg", "kkkkg", "ggggx", "gggxx", "ggxxx", "gxxxx",
                        "xxxxx", "xxxxy", "xxxyy", "xxyyy", "xyyyy", "yyyyy", "yyyyw", "yyyww", "yywww", "ywwww",
                        "wwwww", "wwvww", "wvvww", "vvvww", "vvvwz", "avvwz", "aavwz", "aaawz", "aaaaz"
                        // ReSharper restore StringLiteralTypo
                    },
                    Output = new IList<string>[]
                    {
                        new[]
                        {
                            // ReSharper disable StringLiteralTypo
                            "aaaaa", "aaaaz", "aaawz", "aavwz", "avvwz", "vvvwz", "vvvww", "wvvww", "wwvww", "wwwww",
                            "ywwww", "yywww", "yyyww", "yyyyw", "yyyyy", "xyyyy", "xxyyy", "xxxyy", "xxxxy", "xxxxx",
                            "gxxxx", "ggxxx", "gggxx", "ggggx", "ggggg"
                            // ReSharper restore StringLiteralTypo
                        }
                    },
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    BeginWord = "magic",
                    EndWord = "pearl",
                    WordList = new[]
                    {
                        "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow",
                        "swear", "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends",
                        "deana", "dried", "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider",
                        "scary", "marks", "perry", "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim",
                        "plugs", "cloak", "cyril", "women", "issue", "rocky", "marry", "trash", "merry", "topic",
                        "hicks", "dicky", "prado", "casio", "lapel", "diane", "serer", "paige", "parry", "elope",
                        "balds", "dated", "copra", "earth", "marty", "slake", "balms", "daryl", "loves", "civet",
                        "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore", "felix", "ogled", "acids",
                        // ReSharper disable once StringLiteralTypo
                        "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse", "joist", "grosz",
                        "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke", "scowl",
                        "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party",
                        "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel",
                        "poole", "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts",
                        "ozark", "umped", "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed",
                        // ReSharper disable once StringLiteralTypo
                        "gelds", "italy", "rakes", "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar",
                        "smith", "tangs", "misty", "wefts", "yawns", "smile", "scuff", "width", "paris", "coded",
                        "sodom", "shits", "benny", "pudgy", "mayer", "peary", "curve", "tulsa", "ramos", "thick",
                        "dogie", "gourd", "strop", "ahmad", "clove", "tract", "calyx", "maris", "wants", "lipid",
                        "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai", "waged", "shari", "magic",
                        // ReSharper disable once StringLiteralTypo
                        "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds", "finks", "twits",
                        "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty", "marta",
                        "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth"
                    },
                    Output = new IList<string>[]
                    {
                        new[]
                        {
                            "magic", "manic", "mania", "maria", "marta", "marty", "party", "parry", "perry", "peary",
                            "pearl"
                        },
                        new[]
                        {
                            "magic", "manic", "mania", "maria", "maris", "paris", "parks", "perks", "peaks", "pears",
                            "pearl"
                        },
                        new[]
                        {
                            "magic", "manic", "mania", "maria", "marta", "marty", "marry", "merry", "perry", "peary",
                            "pearl"
                        },
                        new[]
                        {
                            "magic", "manic", "mania", "maria", "marta", "marty", "marry", "parry", "perry", "peary",
                            "pearl"
                        },
                        new[]
                        {
                            "magic", "manic", "mania", "maria", "maris", "marks", "parks", "perks", "peaks", "pears",
                            "pearl"
                        }
                    },
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}
