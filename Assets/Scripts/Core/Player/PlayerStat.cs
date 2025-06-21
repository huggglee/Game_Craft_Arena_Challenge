using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    [SerializeField] float maxMana;
    [SerializeField] float currentMana;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Died();
        }
        Observer.Instance.Broadcast(EventId.OnPlayerUpdateHealth, new System.Tuple<float, float>(currentHealth, maxHealth));

    }
    void Died()
    {
        Debug.Log("Die");
    }
}
