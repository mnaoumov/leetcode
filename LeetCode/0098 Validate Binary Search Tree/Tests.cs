using NUnit.Framework;

namespace LeetCode._0098_Validate_Binary_Search_Tree;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValidBST(TreeNode.Create(testCase.Values)!), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 2, 1, 3 },
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 5, 1, 4, null, null, 3, 6 },
                    Return = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 1, 1 },
                    Return = false,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Values = new int?[]
                    {
                        9963, 9923, 9996, 9900, null, null, null, 9895, null, 9894, null, 9879, null, 9852, null, 9845,
                        null, 9843, null, 9784, null, 9772, null, 9767, null, 9766, null, 9757, null, 9723, null, 9714,
                        null, 9670, null, 9663, null, 9646, null, 9590, null, 9590, null, 9578, null, 9544, null, 9482,
                        null, 9479, null, 9414, null, 9412, null, 9411, null, 9389, null, 9364, null, 9351, null, 9351,
                        null, 9344, null, 9332, null, 9331, null, 9272, null, 9253, null, 9226, null, 9192, null, 9185,
                        null, 9146, null, 9124, null, 9064, null, 9061, null, 8987, null, 8963, null, 8911, null, 8905,
                        null, 8903, null, 8879, null, 8847, null, 8834, null, 8834, null, 8825, null, 8819, null, 8798,
                        null, 8787, null, 8772, null, 8763, null, 8761, null, 8759, null, 8716, null, 8706, null, 8705,
                        null, 8700, null, 8681, null, 8648, null, 8633, null, 8605, null, 8599, null, 8594, null, 8585,
                        null, 8558, null, 8533, null, 8491, null, 8480, null, 8424, null, 8419, null, 8418, null, 8408,
                        null, 8371, null, 8366, null, 8341, null, 8316, null, 8303, null, 8238, null, 8200, null, 8198,
                        null, 8183, null, 8178, null, 8176, null, 8113, null, 8092, null, 8064, null, 8029, null, 8022,
                        null, 7977, null, 7957, null, 7952, null, 7931, null, 7923, null, 7912, null, 7877, null, 7832,
                        null, 7830, null, 7785, null, 7730, null, 7726, null, 7717, null, 7699, null, 7686, null, 7672,
                        null, 7633, null, 7625, null, 7608, null, 7597, null, 7575, null, 7548, null, 7547, null, 7512,
                        null, 7499, null, 7482, null, 7403, null, 7388, null, 7366, null, 7324, null, 7324, null, 7321,
                        null, 7306, null, 7301, null, 7299, null, 7295, null, 7210, null, 7167, null, 7134, null, 7127,
                        null, 7117, null, 7075, null, 7060, null, 6999, null, 6993, null, 6988, null, 6941, null, 6918,
                        null, 6890, null, 6883, null, 6830, null, 6812, null, 6764, null, 6757, null, 6749, null, 6747,
                        null, 6732, null, 6686, null, 6657, null, 6636, null, 6610, null, 6607, null, 6606, null, 6575,
                        null, 6573, null, 6565, null, 6518, null, 6510, null, 6463, null, 6445, null, 6425, null, 6410,
                        null, 6402, null, 6392, null, 6370, null, 6368, null, 6346, null, 6334, null, 6315, null, 6285,
                        null, 6284, null, 6240, null, 6223, null, 6197, null, 6160, null, 6158, null, 6148, null, 6131,
                        null, 6060, null, 6032, null, 6003, null, 5956, null, 5937, null, 5919, null, 5913, null, 5904,
                        null, 5894, null, 5869, null, 5854, null, 5854, null, 5817, null, 5806, null, 5794, null, 5794,
                        null, 5770, null, 5728, null, 5722, null, 5717, null, 5688, null, 5673, null, 5663, null, 5649,
                        null, 5639, null, 5605, null, 5604, null, 5594, null, 5573, null, 5561, null, 5545, null, 5540,
                        null, 5536, null, 5530, null, 5529, null, 5516, null, 5507, null, 5471, null, 5435, null, 5377,
                        null, 5365, null, 5356, null, 5317, null, 5291, null, 5238, null, 5175, null, 5153, null, 5112,
                        null, 5111, null, 5091, null, 5085, null, 5080, null, 5079, null, 5045, null, 5041, null, 5039,
                        null, 5034, null, 5000, null, 4983, null, 4941, null, 4925, null, 4911, null, 4899, null, 4890,
                        null, 4884, null, 4879, null, 4874, null, 4862, null, 4859, null, 4829, null, 4821, null, 4803,
                        null, 4801, null, 4782, null, 4765, null, 4760, null, 4756, null, 4738, null, 4716, null, 4687,
                        null, 4678, null, 4675, null, 4627, null, 4556, null, 4553, null, 4485, null, 4431, null, 4420,
                        null, 4412, null, 4398, null, 4394, null, 4347, null, 4344, null, 4336, null, 4286, null, 4246,
                        null, 4245, null, 4187, null, 4172, null, 4167, null, 4145, null, 4124, null, 4098, null, 4081,
                        null, 4080, null, 4073, null, 4006, null, 3928, null, 3914, null, 3913, null, 3907, null, 3903,
                        null, 3893, null, 3892, null, 3891, null, 3860, null, 3844, null, 3841, null, 3794, null, 3790,
                        null, 3769, null, 3760, null, 3751, null, 3750, null, 3746, null, 3723, null, 3723, null, 3718,
                        null, 3713, null, 3713, null, 3710, null, 3682, null, 3679, null, 3665, null, 3644, null, 3639,
                        null, 3636, null, 3632, null, 3621, null, 3615, null, 3554, null, 3538, null, 3505, null, 3490,
                        null, 3466, null, 3408, null, 3395, null, 3392, null, 3340, null, 3321, null, 3301, null, 3262,
                        null, 3195, null, 3187, null, 3172, null, 3165, null, 3104, null, 3103, null, 2955, null, 2933,
                        null, 2927, null, 2888, null, 2881, null, 2851, null, 2845, null, 2839, null, 2835, null, 2827,
                        null, 2803, null, 2798, null, 2776, null, 2736, null, 2733, null, 2709, null, 2702, null, 2698,
                        null, 2684, null, 2669, null, 2661, null, 2633, null, 2632, null, 2628, null, 2627, null, 2617,
                        null, 2609, null, 2606, null, 2587, null, 2558, null, 2516, null, 2485, null, 2463, null, 2437,
                        null, 2367, null, 2365, null, 2351, null, 2312, null, 2289, null, 2286, null, 2286, null, 2273,
                        null, 2255, null, 2252, null, 2208, null, 2205, null, 2194, null, 2190, null, 2089, null, 2075,
                        null, 2056, null, 2037, null, 2031, null, 2021, null, 2017, null, 1952, null, 1857, null, 1849,
                        null, 1826, null, 1806, null, 1802, null, 1797, null, 1792, null, 1770, null, 1760, null, 1755,
                        null, 1734, null, 1734, null, 1716, null, 1701, null, 1675, null, 1668, null, 1667, null, 1659,
                        null, 1652, null, 1633, null, 1630, null, 1604, null, 1596, null, 1595, null, 1575, null, 1573,
                        null, 1562, null, 1556, null, 1548, null, 1535, null, 1533, null, 1507, null, 1506, null, 1499,
                        null, 1467, null, 1440, null, 1407, null, 1396, null, 1353, null, 1343, null, 1342, null, 1318,
                        null, 1304, null, 1253, null, 1182, null, 1165, null, 1153, null, 1118, null, 1076, null, 1045,
                        null, 1012, null, 961, null, 955, null, 950, null, 937, null, 936, null, 923, null, 883, null,
                        849, null, 839, null, 838, null, 823, null, 820, null, 815, null, 801, null, 800, null, 791,
                        null, 758, null, 738, null, 734, null, 718, null, 712, null, 709, null, 656, null, 649, null,
                        627, null, 611, null, 610, null, 609, null, 602, null, 597, null, 548, null, 514, null, 507,
                        null, 487, null, 441, null, 401, null, 375, null, 372, null, 367, null, 337, null, 327, null,
                        316, null, 306, null, 298, null, 265, null, 219, null, 217, null, 198, null, 191, null, 188,
                        null, 163, null, 87, null, 84, null, 40, null, -5, null, -17, null, -39, null, -69, null, -72,
                        null, -143, null, -145, null, -169, null, -180, null, -206, null, -213, null, -213, null, -244,
                        null, -245, null, -254, null, -302, null, -303, null, -317, null, -319, null, -343, null, -349,
                        null, -375, null, -398, null, -416, null, -417, null, -417, null, -448, null, -495, null, -567,
                        null, -580, null, -588, null, -590, null, -593, null, -618, null, -624, null, -668, null, -730,
                        null, -736, null, -750, null, -756, null, -765, null, -766, null, -809, null, -817, null, -834,
                        null, -843, null, -858, null, -871, null, -921, null, -921, null, -923, null, -932, null, -936,
                        null, -954, null, -991, null, -991, null, -1010, null, -1065, null, -1117, null, -1166, null,
                        -1203, null, -1232, null, -1261, null, -1268, null, -1330, null, -1331, null, -1332, null,
                        -1362, null, -1379, null, -1434, null, -1473, null, -1501, null, -1502, null, -1503, null,
                        -1523, null, -1538, null, -1546, null, -1640, null, -1641, null, -1656, null, -1686, null,
                        -1688, null, -1721, null, -1741, null, -1790, null, -1817, null, -1831, null, -1843, null,
                        -1846, null, -1862, null, -1863, null, -1881, null, -1887, null, -1913, null, -1915, null,
                        -1932, null, -1939, null, -1941, null, -1984, null, -1984, null, -2002, null, -2013, null,
                        -2073, null, -2083, null, -2089, null, -2102, null, -2103, null, -2155, null, -2168, null,
                        -2173, null, -2176, null, -2182, null, -2198, null, -2239, null, -2251, null, -2266, null,
                        -2301, null, -2323, null, -2380, null, -2405, null, -2414, null, -2427, null, -2433, null,
                        -2448, null, -2459, null, -2466, null, -2467, null, -2477, null, -2483, null, -2489, null,
                        -2492, null, -2540, null, -2554, null, -2582, null, -2596, null, -2597, null, -2601, null,
                        -2603, null, -2651, null, -2652, null, -2671, null, -2681, null, -2685, null, -2689, null,
                        -2693, null, -2701, null, -2710, null, -2755, null, -2755, null, -2765, null, -2775, null,
                        -2791, null, -2822, null, -2826, null, -2836, null, -2842, null, -2862, null, -2880, null,
                        -2942, null, -2970, null, -2986, null, -3016, null, -3023, null, -3040, null, -3064, null,
                        -3075, null, -3087, null, -3123, null, -3160, null, -3179, null, -3215, null, -3215, null,
                        -3224, null, -3230, null, -3241, null, -3279, null, -3286, null, -3288, null, -3289, null,
                        -3307, null, -3343, null, -3361, null, -3367, null, -3387, null, -3395, null, -3409, null,
                        -3427, null, -3431, null, -3447, null, -3464, null, -3508, null, -3541, null, -3566, null,
                        -3581, null, -3659, null, -3711, null, -3720, null, -3730, null, -3735, null, -3752, null,
                        -3760, null, -3760, null, -3776, null, -3793, null, -3825, null, -3851, null, -3854, null,
                        -3860, null, -3874, null, -3897, null, -3960, null, -3968, null, -4032, null, -4034, null,
                        -4048, null, -4077, null, -4122, null, -4141, null, -4154, null, -4186, null, -4372, null,
                        -4411, null, -4511, null, -4516, null, -4530, null, -4545, null, -4548, null, -4548, null,
                        -4554, null, -4580, null, -4582, null, -4596, null, -4613, null, -4622, null, -4665, null,
                        -4668, null, -4669, null, -4669, null, -4678, null, -4682, null, -4726, null, -4769, null,
                        -4778, null, -4794, null, -4797, null, -4800, null, -4812, null, -4829, null, -4838, null,
                        -4874, null, -4895, null, -4905, null, -4907, null, -4958, null, -4971, null, -5007, null,
                        -5025, null, -5033, null, -5057, null, -5062, null, -5063, null, -5065, null, -5072, null,
                        -5086, null, -5101, null, -5144, null, -5149, null, -5170, null, -5179, null, -5188, null,
                        -5193, null, -5194, null, -5201, null, -5247, null, -5269, null, -5295, null, -5338, null,
                        -5373, null, -5380, null, -5400, null, -5401, null, -5410, null, -5413, null, -5426, null,
                        -5427, null, -5546, null, -5549, null, -5581, null, -5622, null, -5633, null, -5645, null,
                        -5664, null, -5664, null, -5666, null, -5672, null, -5674, null, -5675, null, -5678, null,
                        -5720, null, -5722, null, -5785, null, -5799, null, -5804, null, -5821, null, -5823, null,
                        -5823, null, -5867, null, -5872, null, -5891, null, -5891, null, -5892, null, -5892, null,
                        -5923, null, -5939, null, -5949, null, -5954, null, -5956, null, -5982, null, -5999, null,
                        -6008, null, -6027, null, -6049, null, -6053, null, -6061, null, -6069, null, -6078, null,
                        -6092, null, -6099, null, -6145, null, -6166, null, -6186, null, -6231, null, -6252, null,
                        -6254, null, -6328, null, -6382, null, -6396, null, -6401, null, -6406, null, -6410, null,
                        -6417, null, -6427, null, -6428, null, -6449, null, -6465, null, -6481, null, -6487, null,
                        -6512, null, -6522, null, -6523, null, -6543, null, -6582, null, -6591, null, -6625, null,
                        -6629, null, -6663, null, -6678, null, -6687, null, -6740, null, -6743, null, -6761, null,
                        -6774, null, -6788, null, -6809, null, -6818, null, -6833, null, -6866, null, -6878, null,
                        -6892, null, -6940, null, -6959, null, -6977, null, -7066, null, -7126, null, -7153, null,
                        -7155, null, -7188, null, -7230, null, -7248, null, -7268, null, -7323, null, -7336, null,
                        -7395, null, -7396, null, -7397, null, -7425, null, -7444, null, -7488, null, -7494, null,
                        -7522, null, -7551, null, -7591, null, -7602, null, -7603, null, -7611, null, -7659, null,
                        -7692, null, -7697, null, -7768, null, -7776, null, -7780, null, -7805, null, -7828, null,
                        -7836, null, -7867, null, -7910, null, -7928, null, -7934, null, -7936, null, -7955, null,
                        -7960, null, -7989, null, -8007, null, -8087, null, -8093, null, -8103, null, -8104, null,
                        -8115, null, -8223, null, -8229, null, -8230, null, -8279, null, -8286, null, -8326, null,
                        -8365, null, -8397, null, -8511, null, -8530, null, -8552, null, -8555, null, -8659, null,
                        -8679, null, -8687, null, -8737, null, -8748, null, -8754, null, -8763, null, -8763, null,
                        -8785, null, -8807, null, -8815, null, -8891, null, -8898, null, -8901, null, -8903, null,
                        -8915, null, -8920, null, -8967, null, -8976, null, -9002, null, -9007, null, -9037, null,
                        -9039, null, -9042, null, -9066, null, -9137, null, -9153, null, -9159, null, -9161, null,
                        -9186, null, -9193, null, -9204, null, -9234, null, -9343, null, -9343, null, -9362, null,
                        -9364, null, -9408, null, -9411, null, -9434, null, -9436, null, -9488, null, -9506, null,
                        -9517, null, -9518, null, -9594, null, -9643, null, -9646, null, -9655, null, -9684, null,
                        -9745, null, -9769, null, -9769, null, -9792, null, -9815, null, -9816, null, -9823, null,
                        -9828, null, -9833, null, -9833, null, -9849, null, -9879, null, -9885, null, -9912, null,
                        -9914, null, -9927
                    },
                    Return = false,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}