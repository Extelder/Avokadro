using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

public class HandHandler : IInitializable, IDisposable
{
    public List<CardVisual> SpawnedCardVisuals { get; private set; } = new List<CardVisual>();
    private CardVisual _cardVisual;
    private HandView _handView;
    private HandConfig _config;
    private Deck _deck;
    private Hand _hand;
    private IHandContainable _handContainable;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public HandHandler(Hand hand, IHandContainable handContainable, HandConfig config, Deck deck, CardVisual cardVisual,
        HandView handView)
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _hand.Play();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                _hand.Discard();
            }
        }).AddTo(_disposable);
        _handView = handView;
        _cardVisual = cardVisual;
        _handContainable = handContainable;
        _hand = hand;
        _config = config;
        _deck = deck;
        _hand.PlayHand += OnPlayHand;
        _hand.DiscardHand += OnDiscardHand;
        _hand.CardsPlayed += OnCardsPlayed;
    }

    private void OnDiscardHand(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            _hand.Cards.Remove(cardVisuals[i].Card);
        }
    }

    private void OnCardsPlayed(CardVisual[] cardVisuals)
    {
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            CardVisual cardVisual = cardVisuals[i];
            sequence.Append(cardVisual.transform.DOLocalMoveY(2000, 0.2f).OnComplete(() =>
            {
                Debug.Log("MVOE");
                OnCardsMoved(cardVisual);
            }));
        }

        sequence.Play().OnComplete(() =>
        {
            Debug.Log("FILL");
            FillHand();
        });
    }

    private void OnCardsMoved(CardVisual cardVisual)
    {
        _handContainable.DestroyObject(cardVisual.gameObject);
        _deck.PutAway(cardVisual.Card);
        _hand.Cards.Remove(cardVisual.Card);
        SpawnedCardVisuals.Remove(cardVisual);
    }

    private void OnPlayHand(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            cardVisuals[i].transform.parent = _handView.PlayHandParent;
            cardVisuals[i].transform.SetParent(_handView.PlayHandParent);
        }

        for (int i = 0; i < SpawnedCardVisuals.Count; i++)
        {
            SpawnedCardVisuals[i].transform.DOLocalMoveY(0, 0.2f);
        }
    }

    public void FillHand()
    {
        int cardsToSpawnCount = _config.CardsCapacity - _hand.Cards.Count;
        for (int i = 0; i < cardsToSpawnCount; i++)
        {
            SpawnCard();
        }

        for (int i = 0; i < SpawnedCardVisuals.Count; i++)
        {
            SpawnedCardVisuals[i].transform.DOLocalMoveY(0, 0.2f);
        }

        _hand.SpawnSelector(SpawnedCardVisuals);
    }


    private void SpawnCard()
    {
        Card card = _deck.Take();
        CardVisual cardVisual = MonoBehaviour.Instantiate(_cardVisual, _handContainable.DefaultSpawnParent);
        cardVisual.transform.DOLocalMoveY(0, 0.2f);

        cardVisual.Init(card);
        SpawnedCardVisuals.Add(cardVisual);
        _hand.Cards.Add(card);
    }

    public void Initialize()
    {
        FillHand();
    }

    public void Dispose()
    {
        _hand.DiscardHand -= OnDiscardHand;
        _disposable?.Clear();
        _hand.PlayHand -= OnPlayHand;
        _hand.CardsPlayed -= OnCardsPlayed;
        _deck?.Dispose();
    }
}