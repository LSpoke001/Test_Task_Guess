using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomTask 
{
    private int _numRandomTask;
    
    public string GetTask(CardBundleData cardBundleData)
    {
        _numRandomTask = Random.Range(0, cardBundleData.CardData.Length);
        return cardBundleData.CardData[_numRandomTask].Identifier;
    }
}
