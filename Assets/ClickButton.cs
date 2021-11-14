using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour, IPointerClickHandler
{
    private CardView _cardData = null;
    private ChekButton _chekButton;
    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _chekButton = GetComponent<ChekButton>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.rawPointerPress.TryGetComponent<CardView>(out _cardData);
        _chekButton.CheckAnswer(_cardData, _spawner.RightAnswer);
    }
}
