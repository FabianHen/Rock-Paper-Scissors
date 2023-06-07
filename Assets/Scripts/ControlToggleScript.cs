using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlToggleScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Toggle thisToggle, toggle1, toggle2;
    [SerializeField] private GameStatus thisStatus;
    private Color colorActive, colorPassive;

    private void Start() {
        colorActive = Color.white;
        colorActive.a = 1f;
        Color col = Color.white;
        col.a = 0.15f;
        colorPassive = col;
    }

    void Update() {
        if (ManagerScript.Instance.status == thisStatus && !thisToggle.isOn){
            thisToggle.isOn = true;
            OnSelect();
        }
    }


    public void OnSelect() {
        if (thisToggle.isOn) {
            ManagerScript.Instance.status = thisStatus;
            thisToggle.interactable = false;
            thisToggle.GetComponent<Image>().color = colorActive;

            toggle1.isOn = false;
            toggle1.interactable = true;
            toggle1.GetComponent<Image>().color = colorPassive;

            toggle2.isOn = false;
            toggle2.interactable = true;
            toggle2.GetComponent<Image>().color = colorPassive;

        }
    }
}
