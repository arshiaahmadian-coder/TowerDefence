using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if(Touchscreen.current == null) return;

        var touch = Touchscreen.current.primaryTouch;
        if (touch.press.wasPressedThisFrame)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector2 screenPos = touch.position.ReadValue();
            
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                if (BuildingsListUI.isOpen && 
                  hit.collider.gameObject.GetComponent<BaseTile>() == Builder.selectedTile)
                {
                    BuildingsListUI.instance.CloseMenu();
                    return;
                }

                // TODO: check if selected tile has no building on it
                // TODO: check if selected tile is road or not
                Builder.selectedTile = hit.collider.gameObject.GetComponent<BaseTile>();
                BuildingsListUI.instance.OpenMenu();
            }
        }
    }
}
