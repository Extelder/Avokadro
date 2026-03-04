using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerProgression
{
    public ReactiveProperty<int> Discards { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> Hands { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> CardsToPlayCapacity { get; private set; } = new ReactiveProperty<int>();

    public PlayerProgression(PlayerConfig config)
    {
        Discards.Value = config.Discards;
        Hands.Value = config.Hands;
        CardsToPlayCapacity.Value = config.CardsToPlayCapacity;
    }
}