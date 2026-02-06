using UnityEngine;
using UnityEngine.Events;

public class InteractableEvent : Interactable
{
    [SerializeField] private UnityEvent<Interactor> interactionEvent;
    public override void Interact(Interactor interactor)
    {
        interactionEvent?.Invoke(interactor);
    }
}
