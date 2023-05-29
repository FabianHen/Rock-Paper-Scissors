using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTextAnimationScript : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Animator anim;
    public void OnPointerEnter(PointerEventData eventData) {
        anim.SetTrigger("Active");
    }
}
