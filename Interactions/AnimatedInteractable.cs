using UnityEngine;

public class AnimatedInteractable : Interactable
{
    [SerializeField] private Animator animator;
    public override void Interact(Interactor interactor)
    {
        animator.SetTrigger("Interact");
    }
}
