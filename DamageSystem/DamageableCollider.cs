using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class DamageableCollider : MonoBehaviour, IDamageable
{
    public Action<int> OnHit;
    public int coefficient = 1;

    public void TakeDamage(int damage)
    {
        OnHit?.Invoke(damage * coefficient);
    }
}
