using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SO_Item> Items = new();
    public List<Socket> Sockets = new();

    [SerializeField] private Interactor interactor;


    private void OnEnable()
    {
        interactor.OnInteracted += OnInteracted;
    }

    private void OnDisable()
    {
        interactor.OnInteracted -= OnInteracted;
    }

    private void OnInteracted(Interactable interactable)
    {
        if(interactable is Pickup)
        {
            Pickup pickup = (Pickup)interactable;
            AddToInventory(pickup.ItemData);
        }
    }

    public void AddToInventory(SO_Item item)
    {
        Items.Add(item);
    }

    public void RemoveFromInventory(SO_Item item)
    {
        if(Items.Contains(item))
            Items.Remove(item);
    }
}
