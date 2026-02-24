using Zenject;
using System.Collections.Generic;


public class Hand
{
    private CardSelector _cardSelector;
    private List<Card> _cards = new List<Card>();

    public Hand(Deck deck, DiContainer container)
    {
        _cardSelector = new CardSelector(_cards, container);
    }

    public void Play()
    {
    }
}