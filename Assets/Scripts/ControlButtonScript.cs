using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class ControlButtonScript : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Toggle pauseButton, resumeButton, fastForwardButton;

    private void Update() {
        if (pauseButton.isOn) {
            ManagerScript.Instance.status = GameStatus.Paused;
        }
        else if(resumeButton.isOn) {
            ManagerScript.Instance.status = GameStatus.Running;
        }
        else {
            ManagerScript.Instance.status = GameStatus.FastForward;
        }
    }
    public void OnCancelClick() {
        ManagerScript.Instance.ClearObjects();
    }

   
}
