using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interactor that uses various casting methods to detect and store interactable objects
/// </summary>
public class CapsuleCastInteractor : Interactor
{
    private enum CastingType
    {
        Raycast,
        SphereCast,
        CapsuleCast,
        BoxCast
    }


    [Header("Casting settings")]

    [SerializeField] private CastingType castingType = CastingType.SphereCast;
    [SerializeField] private float radius = 0.6f;
    [SerializeField] private float maxDistance = 2f;

    private List<Interactable> detected = new List<Interactable>();
    private RaycastHit[] hits;

    private Vector3 start;
    private Vector3 end;

    private void Update()
    {
        UpdateInteractionList();
    }
    void DetectInteractables()
    {
        start = transform.position + transform.forward * 0.5f;
        end = transform.position + transform.forward * 1.5f;

        switch (castingType)
        {
            case CastingType.Raycast:
                hits = Physics.RaycastAll(transform.position, transform.forward, maxDistance, interactionLayers);
                return;

            case CastingType.SphereCast:
                hits = Physics.CapsuleCastAll(start, end, radius, transform.forward, maxDistance, interactionLayers);
                break;

            case CastingType.BoxCast:
                hits = Physics.BoxCastAll(transform.position, Vector3.one * radius, transform.forward, transform.rotation, maxDistance, interactionLayers);
                break;

            case CastingType.CapsuleCast:
                hits = Physics.CapsuleCastAll(start, end, radius, transform.forward, maxDistance, interactionLayers);
                break;
        }


        detected.Clear();

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.TryGetComponent(out Interactable interactable))

                if (useObstructionFiltering && IsObstructed(interactable))
                    continue;

            detected.Add(interactable);
        }
    }

    void UpdateInteractionList()
    {
        bool hadAny = interactables.Count > 0;

        DetectInteractables();

        // removals
        for (int i = interactables.Count - 1; i >= 0; i--)
        {
            if (!detected.Contains(interactables[i]))
                interactables.RemoveAt(i);
        }

        // additions
        foreach (var i in detected)
        {
            if (!interactables.Contains(i))
                interactables.Add(i);
        }

        bool hasAny = interactables.Count > 0;

        if (hadAny != hasAny)
            OnInteractionAvailabilityChanged?.Invoke(hasAny);
    }

}
