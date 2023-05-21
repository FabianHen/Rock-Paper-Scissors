using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Toggle thisToggle, toggle1, toggle2;
    [SerializeField] Type type;


    public void OnSelect() {

        if (thisToggle.isOn) {
            ManagerScript.Instance.SetCurrentType(type);
            thisToggle.interactable = false;

            toggle1.isOn = false;
            toggle1.interactable = true;

            toggle2.isOn = false;
            toggle2.interactable = true;

        }
    } 
}

