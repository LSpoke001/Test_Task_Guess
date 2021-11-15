using UnityEngine;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private string _identifier;
    private Sequence _sequence;
    public string Identifier => _identifier;

    public void Initialization(CardData card)
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = card.Sprite;
        _identifier = card.Identifier;
        BounceEffect();
    }
    public void BounceEffect()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(0.8f, .5f));
        _sequence.Append(transform.DOScale(1.2f, .5f));
        _sequence.Append(transform.DOScale(0.6f, .5f));
        _sequence.Append(transform.DOScale(0.8f, .5f));
    }
    
    public void ShakeButton()
    {
        transform.DOShakePosition(1f);
    }
}
