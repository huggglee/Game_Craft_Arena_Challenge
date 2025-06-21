using DG.Tweening;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float timeToTarget;
    [SerializeField] float radiusEffect;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float damage;
    Tween fallingTween;
    public void Move(Vector3 goal)
    {
        fallingTween = transform.DOMove(goal, timeToTarget)
            .SetEase(Ease.InQuad)
            .OnComplete(() => DealDamage(this.damage, goal));
    }
    public void DealDamage(float damage, Vector3 goal)
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, radiusEffect, playerLayer);
        if(col != null)
        {
            if(col.TryGetComponent<PlayerStat>(out PlayerStat stat))
            {
                stat.TakeDamage(damage);
            }
        }
        Observer.Instance.Broadcast(EventId.OnRocketBoom, goal);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        fallingTween?.Kill();
    }
}
