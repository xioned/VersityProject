using UnityEngine;

public class CarRotate: MonoBehaviour
{
    public bool canRotate = true;
    private Touch touch;
    public float rotateSpeed = 0.1f;
    public float Speed = 10f;
    

    private Quaternion rotationY;
    public bool isRotating = false; 
    public float startMousePosition;

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
            startMousePosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            float currentMousePosition = Input.mousePosition.x;
            float mouseMovement = currentMousePosition - startMousePosition;
            transform.Rotate(Vector3.up, -mouseMovement * Speed * Time.deltaTime);
            startMousePosition = currentMousePosition;
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
