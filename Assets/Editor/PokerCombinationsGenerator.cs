using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public static class PokerCombinationsGenerator
{
    [MenuItem("Tools/Generate Poker Combination Config")]
    public static void Generate()
    {
        var config = ScriptableObject.CreateInstance<CombinationsConfig>();

        var combinations = new List<Combination>()
        {
            CreateHighCard(),
            CreatePair(),
            CreateTwoPair(),
            CreateThree(),
            CreateStraight(),
            CreateFlush(),
            CreateFullHouse(),
            CreateFour(),
            CreateStraightFlush(),
            CreateRoyalFlush()
        };

        SetConfigCombinations(config, combinations);

        const string path = "Assets/PokerCombinations.asset";

        AssetDatabase.CreateAsset(config, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("✅ Poker Combination Config created at: " + path);
    }

    // =====================================================
    // COMBINATIONS
    // =====================================================

    static Combination CreateHighCard()
        => NewCombo("High Card", 1);

    static Combination CreatePair()
        => NewCombo("Pair", 2,
            PairType());

    static Combination CreateTwoPair()
        => NewCombo("Two Pair", 3,
            PairType(),
            PairType());

    static Combination CreateThree()
        => NewCombo("Three of a Kind", 4,
            new CompareCombinationType
            {
                MatchesToFound = 3,
                MatchType = MatchType.Rank
            });

    static Combination CreateStraight()
        => NewCombo("Straight", 5,
            new StraightCombinationType());

    static Combination CreateFlush()
        => NewCombo("Flush", 6,
            new FlushCombinationType());

    static Combination CreateFullHouse()
        => NewCombo("Full House", 7,
            new CompareCombinationType
            {
                MatchesToFound = 3,
                MatchType = MatchType.Rank
            },
            PairType());

    static Combination CreateFour()
        => NewCombo("Four of a Kind", 8,
            new CompareCombinationType
            {
                MatchesToFound = 4,
                MatchType = MatchType.Rank
            });

    static Combination CreateStraightFlush()
        => NewCombo("Straight Flush", 9,
            new StraightCombinationType
            {
                SameSuitRequired = true
            });

    static Combination CreateRoyalFlush()
        => NewCombo("Royal Flush", 10,
            new RoyalFlushType());

    // =====================================================
    // HELPERS
    // =====================================================

    static CompareCombinationType PairType()
    {
        return new CompareCombinationType
        {
            MatchesToFound = 2,
            MatchType = MatchType.Rank,
            NullAfterFoundMatch = true
        };
    }

    static Combination NewCombo(
        string name,
        int priority,
        params CombinationType[] types)
    {
        var combo = new Combination();

        var flags =
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic;

        typeof(Combination)
            .GetProperty("Name", flags)
            ?.SetValue(combo, name);

        typeof(Combination)
            .GetProperty("Priority", flags)
            ?.SetValue(combo, priority);

        typeof(Combination)
            .GetField("_combinationType", flags)
            ?.SetValue(combo, types);

        return combo;
    }

    static void SetConfigCombinations(
        CombinationsConfig config,
        List<Combination> combinations)
    {
        var flags =
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic;

        typeof(CombinationsConfig)
            .GetProperty("Combinations", flags)
            ?.SetValue(config, combinations.ToArray());
    }
}