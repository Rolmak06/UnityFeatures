using System;
using UnityEngine;
using System.Collections.Generic;
public abstract class Interactor : MonoBehaviour
{
    [Header("Interaction Settings")]

    [SerializeField] protected LayerMask interactionLayers;
    [SerializeField] protected LayerMask obstructionLayers;
    [SerializeField] protected bool useObstructionFiltering = true;


    public Action<bool> OnInteractionAvailabilityChanged;
    protected List<Interactable> interactables = new();

    

    #region Common methods
    protected virtual void Interact()
    {
        Interactable closestInteractable = GetClosestAvailableInteractable();

        if (closestInteractable != null)
        {
            closestInteractable.Interact(this);
        }
    }

    private Interactable GetClosestAvailableInteractable()
    {
        if(interactables.Count == 0)
            return null;

        Interactable best = null;
        float bestDist = float.MaxValue;

        foreach (var i in interactables)
        {
            float d = Vector3.Distance(transform.position, i.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                best = i;
            }
        }

        return best;
    }

    protected bool IsObstructed(Interactable interactable)
    {
        if (!useObstructionFiltering)
            return false;

        if (interactable == null)
            return false;

        Vector3 direction = (interactable.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, interactable.transform.position);

        if (Physics.Raycast(transform.position, direction, distance, obstructionLayers))
            return true;

        return false;
    }

    #endregion
}
