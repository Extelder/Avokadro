using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandDiscarder : IDisposable
{
    private Hand _hand;
    private SceneContext _context;
    private PlayableHandConfig _config;

    private HandHandler _handHandler;

    public HandDiscarder(Hand hand, HandHandler handHandler, SceneContext context)
    {
        _context = context;
        _handHandler = handHandler;
        _hand = hand;
        _hand.DiscardHand += OnDiscardHand;
    }

    private void OnDiscardHand(CardVisual[] cardVisuals)
    {
        _context.StartCoroutine(DiscardCards(cardVisuals));
    }

    private IEnumerator DiscardCards(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            if (cardVisuals[i] == null)
                continue;
            Debug.Log("DEstroy");
            MonoBehaviour.Destroy(cardVisuals[i].gameObject);
            _handHandler.SpawnedCardVisuals.Remove(cardVisuals[i]);
        }

        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => CardsDestroyed(cardVisuals));

        Debug.LogError("FILL HAND");
        _handHandler.FillHand();
    }

    private bool CardsDestroyed(CardVisual[] cardVisuals)
    {
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            if (cardVisuals[i] != null)
                return false;
        }

        return true;
    }

    public void Dispose()
    {
        _hand.PlayHand -= OnDiscardHand;
    }

    ~HandDiscarder()
    {
        _hand.PlayHand -= OnDiscardHand;
    }
}