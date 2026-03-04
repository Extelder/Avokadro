using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWinLose : IDisposable
{
    private Hand _hand;
    private Round _round;
    private Score _score;

    public static event Action Winned;
    public static event Action Losed;

    public RoundWinLose(Hand hand, Round round, Score score)
    {
        _hand = hand;
        _score = score;
        _round = round;
        hand.CardsPlayed += OnCardsPlayed;
    }

    private void OnCardsPlayed(CardVisual[] cards)
    {
        if (_score.CurrentValue >= _round.PointsToWin)
        {
            Win();
            return;
        }

        if (_round.Hands == 0)
        {
            Lose();
        }
    }

    public void Win()
    {
        Debug.Log("Win");
        Winned?.Invoke();
    }

    public void Lose()
    {
        Debug.Log("Lose");
        Losed?.Invoke();
    }

    public void Dispose()
    {
        _hand.CardsPlayed -= OnCardsPlayed;
    }
}