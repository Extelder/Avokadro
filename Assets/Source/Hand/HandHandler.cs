using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

public class HandHandler : IInitializable, IDisposable
{
    private List<CardVisual> _spawnedCardVisuals = new List<CardVisual>();

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
        }).AddTo(_disposable);
        _handView = handView;
        _cardVisual = cardVisual;
        _handContainable = handContainable;
        _hand = hand;
        _config = config;
        _deck = deck;
        _hand.PlayHand += OnPlayHand;
    }

    private void OnPlayHand(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            cardVisuals[i].transform.parent = _handView.PlayHandParent;
            cardVisuals[i].transform.SetParent(_handView.PlayHandParent);
        }

        for (int i = 0; i < _spawnedCardVisuals.Count; i++)
        {
            _spawnedCardVisuals[i].transform.DOLocalMoveY(0, 0.2f);
        }
    }

    public void FillHand()
    {
        int cardsToSpawnCount = _config.CardsCapacity - _hand.Cards.Count;
        for (int i = 0; i < cardsToSpawnCount; i++)
        {
            SpawnCard();
        }

        _hand.SpawnSelector(_spawnedCardVisuals);
    }

    private void SpawnCard()
    {
        Card card = _deck.Take();
        CardVisual cardVisual = MonoBehaviour.Instantiate(_cardVisual, _handContainable.DefaultSpawnParent);
        cardVisual.transform.DOLocalMoveY(0, 0.2f);

        cardVisual.Init(card);
        _spawnedCardVisuals.Add(cardVisual);
        _hand.Cards.Add(card);
    }

    public void Initialize()
    {
        FillHand();
    }

    public void Dispose()
    {
        _disposable?.Clear();
        _hand.PlayHand -= OnPlayHand;
        _deck?.Dispose();
    }
}