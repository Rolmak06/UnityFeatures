using UnityEngine;

public class Pickup : Interactable
{
    public SO_Item ItemData;
    public override void Interact(Interactor interactor)
    {
        Debug.Log("This object was picked up", this);
        Destroy(gameObject);
    }
}
