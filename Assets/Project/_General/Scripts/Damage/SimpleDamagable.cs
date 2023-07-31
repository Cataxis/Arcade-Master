using UnityEngine;
using UnityEngine.Events;

public class SimpleDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 3;
    [SerializeField] private UnityEvent onDie;

    private bool alreadyDead = false;
    private int currentHealth;


    private void Awake()
    {
        currentHealth = health;
    }

    public void ResetHealth()
    {
        currentHealth = health;
        alreadyDead = false;
    }
    public void Damage()
    {
        if (alreadyDead) return;

        currentHealth--;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            onDie?.Invoke();
            alreadyDead = true;
        }
    }
}
