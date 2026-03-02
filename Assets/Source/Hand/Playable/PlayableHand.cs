using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayableHand : IDisposable, IInitializable
{
    private Hand _hand;
    private SceneContext _context;
    private PlayableHandConfig _config;
    
    public PlayableHand(Hand hand, SceneContext context, PlayableHandConfig config)
    {
        _context = context;
        _hand = hand;
        _config = config;
        _hand.PlayHand += OnPlayHand;
    }

    private void OnPlayHand(CardVisual[] cardVisuals)
    {
        _context.StartCoroutine(ShowingScore(cardVisuals));
    }

    private IEnumerator ShowingScore(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            yield return new WaitForSeconds(_config.HandPlayCooldown);
            cardVisuals[i].ShowScore(cardVisuals[i].Card.Rank.GetCardValue());
        }
        yield return new WaitForSeconds(_config.HandPlayCooldown);
        _hand.NextHand(cardVisuals);
    }

    public void Dispose()
    {
        _hand.PlayHand -= OnPlayHand;
    }

    public void Initialize()
    {
    }
}
