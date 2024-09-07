using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public UnityAction OnDeath { get; private set; }
    [field: SerializeField] public int CurrentHealth { get; private set; }

    [SerializeField] private bool startFullHealth;

    private void Start() {
        if (startFullHealth) CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount) 
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0) OnDeath?.Invoke();
    }    
}
