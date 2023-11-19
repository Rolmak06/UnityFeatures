using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example class for Damaging a damageable entity. This example demonstrates how to check for layers, tags and damageable interface and how to call the damage function.
/// Those checks allow more control over which entity can be damaged.
/// </summary>
public class Damager : MonoBehaviour
{
   [Tooltip("How much damage is done on hit"), SerializeField] int damage;
   [Tooltip("Do we do damage on collision ?"), SerializeField] bool collision;
   [Tooltip("Do we do damage on trigger ?"), SerializeField] bool trigger = true;
   [Tooltip("Layer selection to check"), SerializeField] LayerMask layerMask;
   [Tooltip("Tag List to check. If not defined, every tag will be considered"), SerializeField] List<string> tags = new List<string>();


   void OnCollisionEnter(Collision col)
   {
        if(collision)
        {
            //Check if the object's layer is in the layer selection
            if ((layerMask.value & (1 << col.transform.gameObject.layer)) > 0)
            {
                //check if the object's tag is in the tag list
                if(tags.Contains(col.gameObject.tag) && tags.Count > 0)
                {
                    //check for a damageable interface
                    if(col.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        damageable.TakeDamage(damage);
                        Debug.LogFormat("{0} is doing {1} damages to {2}", this.gameObject.name, damage, col.gameObject.name);
                    }
                }

                else if(tags.Count < 1)
                {
                    if(col.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        damageable.TakeDamage(damage);
                        Debug.LogFormat("{0} is doing {1} damages to {2}", this.gameObject.name, damage, col.gameObject.name);
                    }
                }
            }
        }
   }

   void OnTriggerEnter(Collider col)
   {
        if(trigger)
        {
            //Check if the object's layer is in the layer selection
            if ((layerMask.value & (1 << col.transform.gameObject.layer)) > 0)
            {
                //check if the object's tag is in the tag list
                if(tags.Contains(col.gameObject.tag) && tags.Count > 0)
                {
                    //check for a damageable interface
                    if(col.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        damageable.TakeDamage(damage);
                        Debug.LogFormat("{0} is doing {1} damages to {2}", this.gameObject.name, damage, col.name);
                    }
                }
                
                //If there's not defined tag, check for interface
                else if(tags.Count < 1)
                {
                    if(col.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        damageable.TakeDamage(damage);
                        Debug.LogFormat("{0} is doing {1} damages to {2}", this.gameObject.name, damage, col.name);
                    }
                }
            }
        }
   }
}
