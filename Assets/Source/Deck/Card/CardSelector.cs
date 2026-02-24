using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class CardSelector
{
    private CompositeDisposable _disposable = new CompositeDisposable();

    [Inject] private Camera _camera;

    public CardSelector(List<Card> cardsToChoose, DiContainer container)
    {
        container.Inject(this);
        RaycastHit hit;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.TryGetComponent<CardVisual>(out CardVisual CardVisual))
                {
                    if (cardsToChoose.Contains(CardVisual.Card))
                    {
                        Debug.Log("Suck");
                    }
                }
            }
        }).AddTo(_disposable);
    }

    ~CardSelector()
    {
        _disposable?.Clear();
    }
}