using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlightScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Selectable button;
    private Color col;
    void Start() {
         col = button.GetComponent<Image>().color;

    }
    public void OnPointerEnter(PointerEventData eventData) {
        col.a = 1;
        button.GetComponent<Image>().color = col;
    }

    public void OnPointerExit(PointerEventData eventData) {
        col.a = 0.15f;
        button.GetComponent<Image>().color = col;      
    }
}
