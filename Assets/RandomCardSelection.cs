using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCardSelection
{
    private List<CardData> _customCard = new List<CardData>();
    private int _numRandomCard = 0;
    private CardData _tmp;
    private CardData _rightCard;

    public void Initialization(CardBundleData cardBundleData)
    {
        _customCard.RemoveAll(a => a != null);
        foreach (var cardData in cardBundleData.CardData)
        {
            _customCard.Add(cardData);
        }
    }
    public CardData GetCard()
    {
        _numRandomCard = Random.Range(0, _customCard.Count);
        _tmp = _customCard[_numRandomCard];
        _customCard.Remove(_tmp);
        return _tmp;
    }

    public CardData GetRightCard(string id)
    {
        foreach (var card in _customCard)
        {
            if (id == card.Identifier)
            {
                _rightCard = card;
                _customCard.Remove(card);
                break;
            }
        }
        return _rightCard;
    }
}
