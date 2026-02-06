using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.AppUI.UI;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIItem uiPrefab;
    [SerializeField] private Transform inventoryHolder;
    [SerializeField] private Inventory inventory;

    private readonly List<UIItem> instances = new();

    private void OnEnable()
    {
        ResetItemGrid();
        PopulateItemGrid();
    }

    private void ResetItemGrid()
    {
        if (instances.Count < 1)
            return;

        for (int i = instances.Count - 1; i >= 0; i--)
        {
            Destroy(instances[i - 1].gameObject);
        }

        instances.Clear();
    }

    public void PopulateItemGrid()
    {
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            UIItem uiItem = Instantiate(uiPrefab, inventoryHolder);
            uiItem.Setup(inventory.Items[i]);
            instances.Add(uiItem);
        }
    }


}
