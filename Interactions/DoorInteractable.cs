using UnityEngine;
using UnityEngine.AI;

public class DoorInteractable : AnimatedInteractable
{
    [SerializeField] NavMeshObstacle obstacle;
    [SerializeField] bool isDoorOpen = false;

    public override void Interact(Interactor interactor)
    {
        base.Interact(interactor);

        isDoorOpen = !isDoorOpen;
        obstacle.carving = !isDoorOpen;
    }
}
