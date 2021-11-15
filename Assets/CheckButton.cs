using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CheckButton : MonoBehaviour
{
    public UnityEvent victoryEvent;
    public UnityEvent stopEvent;
    
    private LevelManager _levelManager;
    private ClickButton _clickButton;

    private void Start()
    {
        _levelManager = GetComponent<LevelManager>();
        _clickButton = GetComponent<ClickButton>();
    }

    public void CheckAnswer(CardView card, string answer)
    {
        if (card.Identifier == answer)
        {
            VictoryButton();
            card.BounceEffect();
        }
        else card.ShakeButton();
    }
    
    private void VictoryButton()
    {
        victoryEvent.Invoke();
        _clickButton.enabled = false;
        StartCoroutine(WaitParticls());
    }
   

    private IEnumerator WaitParticls()
    {
        yield return new WaitForSeconds(3f);
        stopEvent.Invoke();
        _levelManager.ChangeLevel();
        _clickButton.enabled = true;
    }


}
