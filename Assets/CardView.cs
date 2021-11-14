using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private string _identifier;
    public string Identifier => _identifier;
    private Sequence sequence;

    public void Initialized(CardData card)
    {
        _spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = card.Sprite;
        _identifier = card.Identifier;
        BounsEffect();
    }
    public void BounsEffect()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.8f, .5f));
        sequence.Append(transform.DOScale(1.2f, .5f));
        sequence.Append(transform.DOScale(0.6f, .5f));
        sequence.Append(transform.DOScale(0.8f, .5f));
    }
    
    public void ShakeButton()
    {
        transform.DOShakePosition(1f);
    }
}
