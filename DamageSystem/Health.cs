using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class stores health as a int and we can access current health from other script. It offers events both from damage and death.
/// </summary>
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;

// You can also use Action if you prefer, Unity Events are more modular and convenients. 
//    public Action OnDead;
//    public Action OnDamaged;
   public UnityEvent OnDead;
   public UnityEvent OnDamaged;
   public int currentHealth { get; private set; }
   public bool isDead { get; private set;}

    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(isDead){return;}
        currentHealth -= damage;
        HealthCheck();
    }

    void HealthCheck()
    {
        if(currentHealth > 0)
        {
            Hit();
        }

        else
        {
            currentHealth = 0;
            Die();
        }
    }

    void Hit()
    {
        OnDamaged?.Invoke();
        Debug.Log(this.name + " has been damaged. Health : " + currentHealth);
    }


    void Die()
    {
        OnDead?.Invoke();
        isDead = true;
        Debug.Log(this.name + "is dead !");
    }
}
