using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject spawnedPart = null;
    public ItemSlot[] itemSlots;



    public void SelectItem(int id)
    {
        if(spawnedPart != null) { Destroy(spawnedPart); }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].isSelcted = false;
        }
    }
}
