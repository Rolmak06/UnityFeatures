using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Interactor : MonoBehaviour
{
    public enum InteractionUpdateMode
    {
        Trigger,
        CapsuleCast,
        OverlapSphere
    }

    [SerializeField] private LayerMask interactionLayers;
    [SerializeField] private LayerMask obstructionLayers;
    [SerializeField] private bool useObstructionFiltering = true;

    [SerializeField] private InteractionUpdateMode updateMode = InteractionUpdateMode.Trigger;
    [SerializeField] private float radius = 0.6f;
    [SerializeField] private float maxDistance = 2f;

    public event Action OnInteractionAvailable;


    private List<Interactable> interactables = new();
    private List<Interactable> detected = new List<Interactable>();
    private RaycastHit[] hits;
    private Collider[] colliders;
    private Vector3 start;
    private Vector3 end;


    #region Physics Casts
    void DetectInteractables()
    {
        start = transform.position + Vector3.forward * 0.5f;
        end = transform.position + Vector3.forward * maxDistance;
        float radius = 0.6f;

        switch(updateMode)
        {
            case InteractionUpdateMode.Trigger:
                return;

            case InteractionUpdateMode.CapsuleCast:
                hits = Physics.CapsuleCastAll(start, end, radius, transform.forward, maxDistance, interactionLayers);
                break;

            case InteractionUpdateMode.OverlapSphere:
                colliders = Physics.OverlapCapsule(start, end, radius, interactionLayers);
                break;
        }


        detected.Clear();

        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.TryGetComponent(out Interactable interactable))

                if (useObstructionFiltering && IsObstructed(interactable))
                    return;

                detected.Add(interactable);
        }

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Interactable interactable))
                if (useObstructionFiltering && IsObstructed(interactable))
                    return;

            detected.Add(interactable);
        }
    }

    void UpdateInteractionList()
    {
        // 1. detect all interactables this frame
        DetectInteractables();

        // 2. handle removals
        for (int i = interactables.Count - 1; i >= 0; i--)
        {
            if (!detected.Contains(interactables[i]))
            {
                // they disappeared
                interactables.RemoveAt(i);
            }
        }

        // 3. handle additions
        foreach (var i in detected)
        {
            if (!interactables.Contains(i))
            {
                interactables.Add(i);
            }
        }
    }
    #endregion

    #region Trigger

    private void OnTriggerEnter(Collider other)
    {
        if ((interactionLayers & (1 << other.gameObject.layer)) == 0)
            return;

        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            if(interactables.Contains(interactable)) 
                return;

            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((interactionLayers & (1 << other.gameObject.layer)) == 0)
            return;

        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            if(interactables.Contains(interactable))
                interactables.Remove(interactable);
        }
    }
    #endregion

    #region Common methods
    private void Interact()
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

        return interactables.OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).FirstOrDefault();
    }

    private bool IsObstructed(Interactable interactable)
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
