using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public class Combination
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public int Priority { get; private set; }

    [SerializeReference] [SerializeReferenceButton] [SerializeField]
    private CombinationType[] _combinationType;

    public bool CombinationCompares(Card[] cards)
    {
        Card[] newCards = new Card[cards.Length];
        for (int i = 0; i < newCards.Length; i++)
        {
            newCards[i] = cards[i];
        }

        for (int i = 0; i < _combinationType.Length; i++)
        {
            if (!_combinationType[i].Match(ref newCards))
                return false;
        }

        return true;
    }
}

public enum MatchType
{
    Rank,
    Suit,
    RankAndSuit
}

[System.Serializable]
public class StraightCombinationType : CombinationType
{
    [field: SerializeField] public bool SameSuitRequired { get; set; }

    public override bool Match(ref Card[] cards)
    {
        if (cards.Length < 5)
            return false;

        var ordered = cards
            .Select(c => (int) c.Rank)
            .Distinct()
            .OrderBy(x => x)
            .ToArray();

        int consecutive = 1;

        for (int i = 1; i < ordered.Length; i++)
        {
            if (ordered[i] == ordered[i - 1] + 1)
            {
                consecutive++;

                if (consecutive >= 5)
                {
                    if (!SameSuitRequired)
                        return true;

                    var suitGroups = cards.GroupBy(c => c.Suit);
                    return suitGroups.Any(g => g.Count() >= 5);
                }
            }
            else
            {
                consecutive = 1;
            }
        }

        return false;
    }
}


[System.Serializable]
public class RoyalFlushType : CombinationType
{
    public override bool Match(ref Card[] cards)
    {
        var needed = new[] {10, 11, 12, 13, 14};

        var suitGroups = cards.GroupBy(c => c.Suit);

        foreach (var group in suitGroups)
        {
            var ranks = group.Select(c => (int) c.Rank);

            if (needed.All(r => ranks.Contains(r)))
                return true;
        }

        return false;
    }
}

[System.Serializable]
public class FlushCombinationType : CombinationType
{
    public override bool Match(ref Card[] cards)
    {
        return cards
            .GroupBy(c => c.Suit)
            .Any(g => g.Count() >= 5);
    }
}


[Serializable]
public class CompareCombinationType : CombinationType
{
    [field: SerializeField] public int MatchesToFound { get; set; }
    [field: SerializeField] public MatchType MatchType { get; set; }
    [field: SerializeField] public bool NullAfterFoundMatch { get; set; }


    public override bool Match(ref Card[] cards)
    {
        List<Card> cardsList = new List<Card>();
        for (int i = 0; i < cards.Length; i++)
        {
            cardsList.Add(cards[i]);
        }

        switch (MatchType)
        {
            case MatchType.Rank:
                for (int j = 0; j < cardsList.Count; j++)
                {
                    Debug.Log(cardsList[j]);
                    int count = cardsList.Count(x => x.Rank == cardsList[j].Rank);
                    if (count >= MatchesToFound)
                    {
                        var newList = cardsList
                            .Where(x => x.Rank == cardsList[j].Rank)
                            .ToList();
                        foreach (var card in newList)
                            cardsList.Remove(card);
                        if (NullAfterFoundMatch)
                        {
                            cards = cardsList.ToArray();
                        }

                        return true;
                    }
                }

                break;

            case MatchType.Suit:
                for (int j = 0; j < cardsList.Count; j++)
                {
                    int count = cardsList.Count(x => x.Suit == cardsList[j].Suit);
                    if (count >= MatchesToFound)
                    {
                        var newList = cardsList
                            .Where(x => x.Suit == cardsList[j].Suit)
                            .ToList();
                        foreach (var card in newList)
                            cardsList.Remove(card);
                        if (NullAfterFoundMatch)
                        {
                            cards = cardsList.ToArray();
                        }

                        return true;
                    }
                }

                break;

            case MatchType.RankAndSuit:
                for (int j = 0; j < cardsList.Count; j++)
                {
                    int count = cardsList.Count(x => x.Rank == cardsList[j].Rank && x.Suit == cardsList[j].Suit);
                    if (count >= MatchesToFound)
                    {
                        var newList = cardsList
                            .Where(x => x.Rank == cardsList[j].Rank && x.Suit == cardsList[j].Suit)
                            .ToList();
                        foreach (var card in newList)
                            cardsList.Remove(card);
                        if (NullAfterFoundMatch)
                        {
                            cards = cardsList.ToArray();
                        }

                        return true;
                    }
                }

                break;
        }


        return false;
    }
}

[Serializable]
public abstract class CombinationType
{
    public abstract bool Match(ref Card[] cards);
}


public static class CardCombinationExtensions
{
    public static Combination GetBestCombination(
        this Card[] cards,
        CombinationsConfig config)
    {
        if (cards == null || cards.Length == 0)
            return null;

        if (config == null || config.Combinations == null)
            return null;

        Combination best = null;
        int bestPriority = int.MinValue;

        foreach (var combo in config.Combinations)
        {
            if (combo == null)
                continue;

            if (combo.CombinationCompares(cards))
            {
                if (combo.Priority > bestPriority)
                {
                    bestPriority = combo.Priority;
                    best = combo;
                }
            }
        }

        return best;
    }

    public static Combination GetBestCombination(
        this List<Card> cards,
        CombinationsConfig config)
    {
        if (cards == null)
            return null;

        return GetBestCombination(cards.ToArray(), config);
    }

    public static Combination GetBestCombination(
        this List<CardVisual> cards,
        CombinationsConfig config)
    {
        if (cards == null)
            return null;

        Card[] defcards = new Card[cards.Count];
        for (int i = 0; i < defcards.Length; i++)
        {
            defcards[i] = cards[i].Card;
            Debug.Log(defcards[i]);
        }

        return GetBestCombination(defcards, config);
    }
}