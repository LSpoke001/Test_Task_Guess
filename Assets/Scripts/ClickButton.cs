using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour, IPointerClickHandler
{
    private CardView _cardData = null;
    private CheckButton _checkButton;
    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _checkButton = GetComponent<CheckButton>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.rawPointerPress.TryGetComponent<CardView>(out _cardData);
        _checkButton.CheckAnswer(_cardData, _spawner.RightAnswer);
    }
}
