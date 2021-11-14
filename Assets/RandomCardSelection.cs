using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCardSelection
{
    private List<CardData> _castomCard = new List<CardData>();
    private int numRandomCard = 0;
    private CardData tmp;
    private CardData rightCard;

    public void Initilize(CardBundleData cardBundleData)
    {
        _castomCard.RemoveAll(a => a != null);
        foreach (var cardData in cardBundleData.CardData)
        {
            _castomCard.Add(cardData);
        }
    }
    public CardData GetCard()
    {
        numRandomCard = Random.Range(0, _castomCard.Count);
        tmp = _castomCard[numRandomCard];
        _castomCard.Remove(tmp);
        return tmp;
    }

    public CardData GetRightCard(string id)
    {
        foreach (var card in _castomCard)
        {
            if (id == card.Identifier)
            {
                rightCard = card;
                _castomCard.Remove(card);
                break;
            }
        }
        return rightCard;
    }
}
