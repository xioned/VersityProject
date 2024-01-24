using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartAttach : MonoBehaviour
{
    public Camera cam;
    public GameObject spawnedPart = null;
    public LayerMask groundLayer;
    private void Update()
    {
        if (spawnedPart != null)
        {
            Ray ray2 = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out RaycastHit raycastHit, 200, groundLayer))
            {
                spawnedPart.transform.position = new(raycastHit.point.x,spawnedPart.transform.position.y, raycastHit.point.z);
            }
        }



        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, mousePos - transform.position, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Debug.Log(hit.collider.gameObject.GetComponent<CartPart>().partCode);
        }
    }
}
