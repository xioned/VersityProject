using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartAttach : MonoBehaviour
{
    public Camera cam;
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cam.transform.position, mousePos - transform.position, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.GetComponent<CartPart>().partCode);
        }
        
        
    }
}
