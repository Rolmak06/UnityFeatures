using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This script is linked to a IDamageable script (health script) and serves as a bridge between damageable colliders and the health script.
/// </summary>
/// 
[RequireComponent(typeof(IDamageable))]
public class DamageableColliderList : MonoBehaviour
{
    IDamageable healthScript;
    [SerializeField] List<DamageableCollider> colliders = new List<DamageableCollider>();

   void OnEnable()
   {
        healthScript = GetComponent<IDamageable>();
        SubscribeToColliders(); 
   }

   void OnDisable()
   {
        UnsubscribeToColliders();
   }

    /// <summary>
    /// Process the damage event and pass it to the main health script.
    /// </summary>
    /// <param name="damage">How much damage is passed to the health script</param>
    void HandleHit(int damage)
    {
        healthScript.TakeDamage(damage);
    }

    /// <summary>
    /// Subscribe to collision events foreach defined colliders.
    /// </summary>
    void SubscribeToColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].OnHit += HandleHit;
        }
    }

    /// <summary>
    /// Unsubscribe to avoid any memory leak.
    /// </summary>
    void UnsubscribeToColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].OnHit -= HandleHit;
        }
    }

    /// <summary>
    /// Editor function to retrieve all damageable colliders in this object hierarchy
    /// </summary>

    [ContextMenu("Get All Children Damageable Colliders")]
    void GetChildrenColliders()
    {
        colliders.Clear();

        colliders = GetComponentsInChildren<DamageableCollider>(true).ToList();
    }
}

