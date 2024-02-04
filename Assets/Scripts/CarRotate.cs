using UnityEngine;

public class CarRotate: MonoBehaviour
{
    public bool canRotate = true;
    private Touch touch;
    public float rotateSpeed = 0.1f;
    public float Speed = 10f;
    

    private Quaternion rotationY;
    public bool isRotating = false; 
    public Vector2 startMousePosition;

    void Update()
    {
        if(!canRotate) return;
        MouseRotate();
    }
    private void MouseRotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            startMousePosition.x = Input.mousePosition.x;
            startMousePosition.y = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            float currentMousePositionx = Input.mousePosition.x;
            float mouseMovementx = currentMousePositionx - startMousePosition.x;
            transform.Rotate(Vector3.up, -mouseMovementx * Speed * Time.deltaTime);
            startMousePosition.x = currentMousePositionx;

            //float currentMousePositiony = Input.mousePosition.y;
            //float mouseMovementy = currentMousePositiony - startMousePosition.y;
            //transform.Rotate(Vector3.right, -mouseMovementy * Speed * Time.deltaTime);
            //startMousePosition.y = currentMousePositiony;
        }
    }

    private void TouchRotation()
    {
        if (Input.touchCount > 0)
        {
            touch  = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x*rotateSpeed, 0f);
                transform.rotation = rotationY*transform.rotation;
            }
        }

    }
}
