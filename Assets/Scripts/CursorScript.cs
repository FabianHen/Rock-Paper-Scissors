using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D insideCursor, outsideCursor;

    private void Start() {
        Cursor.SetCursor(outsideCursor, new Vector2(10, 0), CursorMode.Auto);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Cursor.SetCursor(insideCursor, new Vector2(10, 0), CursorMode.Auto);
        ManagerScript.Instance.SetObjectsPlaceable(false);
    }
    public void OnPointerExit(PointerEventData eventData) {
        if (ManagerScript.Instance.status == GameStatus.Paused) {
            Cursor.SetCursor(outsideCursor, new Vector2(10, 0), CursorMode.Auto);
            ManagerScript.Instance.SetObjectsPlaceable(true);
        }
    }
}
