using System;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private Sprite pointIn, pointOut;
    [SerializeField] private Animator anim;
    private bool isPointingOut;

    private void Start() {
        isPointingOut = true;
    }


    public void OnClick() {
        if (isPointingOut) {
            gameObject.GetComponent<Image>().sprite = pointIn;
            anim.SetTrigger("Push");
            isPointingOut = false;
        } else {
            gameObject.GetComponent<Image>().sprite = pointOut;
            anim.SetTrigger("Pull");
            isPointingOut = true;   
        }
    }
}
