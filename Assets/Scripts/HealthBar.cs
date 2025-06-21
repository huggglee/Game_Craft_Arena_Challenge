using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbarImage;
    private void Start()
    {
        Observer.Instance.Register(EventId.OnPlayerUpdateHealth, HealthBar_OnPlayerUpdateHealth);
    }
    void HealthBar_OnPlayerUpdateHealth(object obj)
    {
        var tuple = obj as System.Tuple<float, float>;
        healthbarImage.fillAmount = tuple.Item1 / tuple.Item2;
    }
    private void OnDestroy()
    {
        Observer.Instance.Unregister(EventId.OnPlayerUpdateHealth, HealthBar_OnPlayerUpdateHealth);
    }
}
