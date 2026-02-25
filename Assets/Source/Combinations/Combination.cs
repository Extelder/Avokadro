using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Combination/New Combination Config")]
public class CombinationsConfig : ScriptableObject
{
    [field: SerializeField] public Combination[] Combinations { get; private set; }
}

[Serializable]
public class Combination
{
    [field: SerializeField] public int Priority { get; private set; }

    [SerializeField] private CombinationType[] _combinationType;

    public bool CombinationCompares(Card[] cards)
    {
        for (int i = 0; i < _combinationType.Length; i++)
        {
            if (!_combinationType[i].Match(cards))
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

[Serializable]
public class CompareCombinationType : CombinationType
{
    [field: SerializeField] public int MatchesToFound { get; private set; }
    [field: SerializeField] public MatchType MatchType { get; private set; }

    public override bool Match(Card[] cards)
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
                    int count = cardsList.Count(x => x.Rank == cardsList[j].Rank);
                    if (count >= MatchesToFound)
                    {
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
                        return true;
                    }
                }

                break;
        }


        return false;
    }
}

public abstract class CombinationType
{
    public abstract bool Match(Card[] cards);
}