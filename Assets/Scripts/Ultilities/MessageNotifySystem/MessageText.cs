using DG.Tweening;
using TMPro;
using UnityEngine;

public class MessageText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    Tween moveTween;
    Tween fadeTween;
    public void SetText(string message)
    {
        text.text = message;
        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.anchoredPosition = Vector2.zero;
        RectTransform itemRect = gameObject.GetComponent<RectTransform>();
        moveTween = transform.DOMoveY(transform.position.y + 500, 2f).SetEase(Ease.OutQuad);
        fadeTween = text.DOFade(0.7f, 2f).OnComplete(() => gameObject.SetActive(false));
    }
    private void OnDisable()
    {
        moveTween?.Kill();
        fadeTween?.Kill();
    }
}
