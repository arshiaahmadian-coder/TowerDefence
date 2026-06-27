using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float senstivity = 0.01f;

    [Header("Clamp points")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private Vector2 lastPointerPosition;

    private void Update()
    {
        if (Mouse.current != null)
        {
            HandleMouse();
        }

        if (Touchscreen.current != null)
        {
            HandleTouch();
        }
    }

    private void HandleMouse()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            lastPointerPosition = Mouse.current.position.ReadValue();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 currentPosition = Mouse.current.position.ReadValue();
            MoveCamera(currentPosition);
        }
    }

    private void HandleTouch()
    {
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            lastPointerPosition =
                Touchscreen.current.primaryTouch.position.ReadValue();
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 currentPosition =
                Touchscreen.current.primaryTouch.position.ReadValue();

            MoveCamera(currentPosition);
        }
    }

    private void MoveCamera(Vector2 currentPosition)
    {
        Vector2 delta = currentPosition - lastPointerPosition;

        Vector3 pos = transform.position;

        pos -= new Vector3(
            delta.x * senstivity,
            delta.y * senstivity,
            0
        );

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        lastPointerPosition = currentPosition;
    }
}