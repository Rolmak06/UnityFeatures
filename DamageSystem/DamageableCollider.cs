using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class DamageableCollider : MonoBehaviour, IDamageable
{
    // Use of an action for the propagation of the hit
    public Action<int> OnHit;
    public int coefficient = 1;

    ///<summary>
    /// Calls the take damage function from the interface
    ///</summary>
    public void TakeDamage(int damage)
    {
        OnHit?.Invoke(damage * coefficient);
    }
}
