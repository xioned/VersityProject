using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PartAttach : MonoBehaviour
{
    public Camera cam;
    public GameObject spawnedPart = null;
    public LayerMask groundLayer;
    public Transform ground;
    public Transform parent;
    public Vector3[] groundPos;
    public GameObject[] ghostObject;
    public GameObject done;
    public GameObject activeGhost;
    public int id;
    public InventoryManager inventoryManager;
    public CarRotate carRotate;
    internal void SetGroundHeight(int id)
    {
        this.id = id;
        activeGhost = null;
        for (int i = 0; i < ghostObject.Length; i++)
        {
            ghostObject[i].SetActive(false);
        }

        for (int i = 0; i < ghostObject.Length; i++)
        {
            if (ghostObject[i].GetComponent<CartPart>().partCode == id)
            {
                ghostObject[i].SetActive(true);
                activeGhost = ghostObject[i];
            }
        }
    }
    public void ShowGhost()
    {
        for (int i = 0; i < ghostObject.Length; i++)
        {
            ghostObject[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (spawnedPart != null)
        {
            Ray ray2 = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out RaycastHit raycastHit, 200, groundLayer))
            {
                spawnedPart.transform.position = new(raycastHit.point.x,spawnedPart.transform.position.y, raycastHit.point.z);
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 100f;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(cam.transform.position, mousePos - transform.position, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<CartPart>() && spawnedPart != null)
                {
                    if (hit.collider.gameObject.GetComponent<CartPart>().partCode == id
                        && Vector3.Distance(spawnedPart.transform.position, activeGhost.transform.position) < 4)
                    {
                        spawnedPart.transform.position = activeGhost.transform.position;
                        spawnedPart.transform.parent = parent;
                        activeGhost.transform.parent = done.transform;
                        activeGhost.SetActive(false);
                        ShowGhost();
                        inventoryManager.ResetInventory();
                    }

                }
            }
        }

        
    }
}
