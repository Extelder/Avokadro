using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class CardSelector
{
    [Inject] private Camera _camera;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public CardSelector(List<CardVisual> cardsToChoose, DiContainer container)
    {
        container.Inject(this);
        foreach (var card in cardsToChoose)
        {
            Debug.Log("START FOREACH");
            card.CardImage.OnPointerClickAsObservable().Subscribe(_ =>
            {
                Debug.Log("ddddYAICA");
            }).AddTo(_disposable);
        }
    }

    ~CardSelector()
    {
        _disposable.Clear();
    }
}