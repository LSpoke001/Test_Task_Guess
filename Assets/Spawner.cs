using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float _xStep = 4.5f;
    [SerializeField]private float _yStep = 2.5f;
    [SerializeField]private int _lineBreak = 3;

    [SerializeField]private Transform _easyLevel;
    [SerializeField]private Transform _middleLevel;
    [SerializeField]private Transform _hardLevel;
    
    private Vector3 _tmpVector;
    
    private RandomCardSelection _rndCard = new RandomCardSelection();
    private RandomTask _rndTask = new RandomTask();
    private int _rndCardSet = 0;
    private int _rndRightCard = 0;

    private string _rightAnswer;
    private CardData _rightCard = null;
    
    private int _easy = 0;
    private int _middle = 3;
    private int _hard = 6;
    

    public string RightAnswer => _rightAnswer;

    public event UnityAction<string> Changed;

    private void Start()
    {
        Changed?.Invoke(_rightAnswer);
    }

    public void CreateLevel(CardBundleData[] cardBundleData, int quantity, CardView cardView)
    {
        StartPoint(quantity);
        _rndCardSet = Random.Range(0, cardBundleData.Length);
        SpawnTask(cardBundleData[_rndCardSet]);
        SpawnCard(cardBundleData[_rndCardSet], quantity, cardView);
    }
    private void StartPoint(int quantity)
    {
        if (quantity > _hard) transform.position = _hardLevel.position;
        else if (quantity > _middle) transform.position = _middleLevel.position;
        else transform.position = _easyLevel.position;

        _tmpVector = transform.position;
    }

    private void SpawnTask(CardBundleData cardBundleData)
    {
        _rightAnswer = _rndTask.GetTask(cardBundleData);
        Changed?.Invoke(_rightAnswer);
    }
    
    private void SpawnCard(CardBundleData cardBundleData, int quantity, CardView cardView)
    {
        _rndRightCard = Random.Range(0, quantity);
        _rndCard.Initialization(cardBundleData);
        _rightCard = _rndCard.GetRightCard(_rightAnswer);
        
        for (int i = 0; i < quantity; i++)
        {
            if (i % _lineBreak == 0 && i != 0)
            {
                _tmpVector.x = transform.position.x;
                _tmpVector.y -= _yStep;
            }
            CardView newCard = Instantiate(cardView, transform);
            newCard.transform.position = _tmpVector;
            if (i == _rndRightCard) newCard.Initialization(_rightCard);
            else newCard.Initialization(_rndCard.GetCard());
            
            _tmpVector.x += _xStep;
        }
    }
}
