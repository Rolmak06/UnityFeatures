using UnityEngine;

/// <summary>
/// An interactor that uses trigger colliders to detect and store interactable objects
/// </summary>
public class TriggerInteractor : Interactor
{
    #region Trigger

    private void OnTriggerEnter(Collider other)
    {
        if ((interactionLayers & (1 << other.gameObject.layer)) == 0)
            return;

        bool hadAny = interactables.Count > 0;

        if (other.TryGetComponent(out Interactable i) && !interactables.Contains(i))
            interactables.Add(i);

        bool hasAny = interactables.Count > 0;

        if (hadAny != hasAny)
            OnInteractionAvailabilityChanged?.Invoke(hasAny);
    }

    private void OnTriggerExit(Collider other)
    {
        if ((interactionLayers & (1 << other.gameObject.layer)) == 0)
            return;

        bool hadAny = interactables.Count > 0;

        if (other.TryGetComponent(out Interactable i))
            interactables.Remove(i);

        bool hasAny = interactables.Count > 0;

        if (hadAny != hasAny)
            OnInteractionAvailabilityChanged?.Invoke(hasAny);
    }
    #endregion
}
