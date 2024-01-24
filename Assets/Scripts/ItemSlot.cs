using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public bool isSelcted = false;
    public int id;
    public GameObject carPartPrefab;
    public InventoryManager inventoryManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SelectItem(id);

    }
}
