using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot selectedSlot;
    public ItemSlot[] itemSlots;
    public PartAttach partAttach;
    public CarRotate carRotate;

    public void SelectItem(ItemSlot itemSlot)
    {
        carRotate.canRotate = false;
        if (partAttach.spawnedPart != null) { Destroy(partAttach.spawnedPart); }
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].GetComponent<Image>().color = Color.white;
        }

        if (selectedSlot == itemSlot)
        {
            selectedSlot = null;
            carRotate.canRotate = true;
            partAttach.ShowGhost();

            return;
        }
        selectedSlot = itemSlot;
        itemSlot.GetComponent<Image>().color = Color.green;
        partAttach.spawnedPart = Instantiate(itemSlot.carPartPrefab);
        partAttach.spawnedPart.transform.rotation = carRotate.transform.rotation;
        partAttach.SetGroundHeight(itemSlot.id);
    }

    public void ResetInventory()
    {
        partAttach.spawnedPart = null;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].isSelcted = false;
            itemSlots[i].GetComponent<Image>().color = Color.white;
        }
        carRotate.startMousePosition = Input.mousePosition.x;
        carRotate.canRotate = true;
        carRotate.isRotating = false;
        selectedSlot.gameObject.SetActive(false);
    }
}
