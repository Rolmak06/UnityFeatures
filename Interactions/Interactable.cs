using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteract;
    public virtual void Interact(Interactor interactor)
    {
        onInteract?.Invoke();
    }
}
