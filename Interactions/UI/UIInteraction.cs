using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private GameObject uiHolder;
    [SerializeField] private Interactor interactor;

    private void OnEnable()
    {
        interactor.OnAvailabilityChanged += InteractionAvailability;
    }

    private void OnDisable()
    {
        interactor.OnAvailabilityChanged -= InteractionAvailability;
    }

    private void InteractionAvailability(bool isAvailable)
    {
        uiHolder.SetActive(isAvailable);
    }
}
