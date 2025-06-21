using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject playerDeathEffect;

    public void Start()
    {
        Observer.Instance.Register(EventId.OnRocketBoom, EffectManager_SpawnEffectDestroy);

    }
    public void EffectManager_SpawnEffectDestroy(object obj)
    {
        Vector3 postition = (Vector3)obj;
        if (playerDeathEffect != null)
        {
            GameObject effect = MyPoolManager.Instance.GetFromPool(playerDeathEffect, transform);
            effect.transform.position = postition;
        }
    }
    public void OnDestroy()
    {
        Observer.Instance.Unregister(EventId.OnRocketBoom, EffectManager_SpawnEffectDestroy);
    }
}