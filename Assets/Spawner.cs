using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float xStep;
    [SerializeField]private float yStep;

    private Vector3 eazyLevel = new Vector3(-4, -1, 2f);
    private Vector3 middleLevel = new Vector3(-4, 0, 2f);
    private Vector3 hirdLevel = new Vector3(-4, 1.5f, 2f);
    private Vector2 tmpVector;
    
    private RandomCardSelection rndCard = new RandomCardSelection();
    private RandomTask rndTask = new RandomTask();
    private int rndSet = 0;
    private int rndRightCard = 0;
    
    private string _rightAnswer = null;
    private CardData rightCard = null;

    public string RightAnswer => _rightAnswer;

    public event UnityAction<string> Changed;

    private void Start()
    {
        Changed?.Invoke(_rightAnswer);
    }

    public void CreateLevel(CardBundleData[] cardBundleData, int quantity, CardView cardView)
    {
        StartPoint(quantity);
        rndSet = Random.Range(0, cardBundleData.Length);
        SpawnTask(cardBundleData[rndSet]);
        SpawnCard(cardBundleData[rndSet], quantity, cardView);
    }
    private void StartPoint(int quantity)
    {
        if (quantity > 6) transform.position = hirdLevel;
        else if (quantity > 3) transform.position = middleLevel;
        else transform.position = eazyLevel;

        tmpVector = transform.position;
    }

    private void SpawnTask(CardBundleData cardBundleData)
    {
        _rightAnswer = rndTask.GetTask(cardBundleData);
        Changed?.Invoke(_rightAnswer);
    }
    
    private void SpawnCard(CardBundleData cardBundleData, int quantity, CardView cardView)
    {
        rndRightCard = Random.Range(0, quantity);
        rndCard.Initilize(cardBundleData);
        rightCard = rndCard.GetRightCard(_rightAnswer);
        
        for (int i = 0; i < quantity; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                tmpVector.x = transform.position.x;
                tmpVector.y = tmpVector.y - yStep;
            }
            CardView newCard = Instantiate(cardView, transform);
            newCard.transform.position = tmpVector;
            if (i == rndRightCard) newCard.Initialized(rightCard);
            else newCard.Initialized(rndCard.GetCard());
            
            tmpVector.x = tmpVector.x + xStep;
        }
    }
}
