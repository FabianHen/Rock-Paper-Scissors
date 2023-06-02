using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTextAnimationScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator anim;
    public void OnPointerEnter(PointerEventData eventData) {
        anim.SetTrigger("Active");
    }

    public void OnPointerExit(PointerEventData eventData) {
        anim.ResetTrigger("Active");
    }
}
