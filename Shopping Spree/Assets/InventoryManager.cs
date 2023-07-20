using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySquare[] inventorySquares;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySquares.Length; i++)
        {
            InventorySquare square = inventorySquares[i];
            DraggableItem itemInSquare = square.GetComponentInChildren<DraggableItem>();
            if (itemInSquare == null)
            {
                SpawnNewItem(item, square);
                return;
            }
        }

    }

    void SpawnNewItem(Item item, InventorySquare square)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, square.transform);
        DraggableItem draggableItem = newItemGo.GetComponent<DraggableItem>();
        draggableItem.InitializeItem(item);
    }
}
