using UnityEngine;

public class PhysicInteractable : Interactable
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 10f;
    [SerializeField] ForceMode forceMode = ForceMode.Impulse;

    private void Reset()
    {
        TryGetComponent(out rb);
    }
    public override void Interact(Interactor interactor)
    {
        if (rb == null)
            return;

        Vector3 direction = transform.position - interactor.transform.position;
        rb.AddForce(direction.normalized * force, forceMode);
    }
}
