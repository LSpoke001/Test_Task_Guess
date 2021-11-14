using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ChekButton : MonoBehaviour
{
    public UnityEvent victoryEvent;
    public UnityEvent _stopEvent;
    //private Spawner _spawner;
    //private CardView _cardData = null;
    private LevelManager _levelManager;
    private ClickButton _clickButton;

    private void Start()
    {
       // _spawner = GetComponent<Spawner>();
        _levelManager = GetComponent<LevelManager>();
        _clickButton = GetComponent<ClickButton>();
    }


    /*public void OnPointerClick(PointerEventData eventData)
    {
        eventData.rawPointerPress.TryGetComponent<CardView>(out _cardData);
        CheckAnswer(_cardData, _spawner.RightAnswer);
    }*/

    public void CheckAnswer(CardView card, string answer)
    {
        if (card.Identifier == answer)
        {
            VictoryButton();
        }
        else card.ShakeButton();
    }
    
    public void VictoryButton()
    {
        victoryEvent.Invoke();
        _clickButton.enabled = false;
        StartCoroutine(WaitParticls());
    }
   

    private IEnumerator WaitParticls()
    {
        yield return new WaitForSeconds(3f);
        _stopEvent.Invoke();
        _levelManager.ChangeLevel();
        _clickButton.enabled = true;
    }


}
