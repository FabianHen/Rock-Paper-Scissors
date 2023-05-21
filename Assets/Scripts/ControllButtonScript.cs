using UnityEngine;
using UnityEngine.UI;

public class ControllButtonScript : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    //[SerializeField] private Toggle pauseButton, resumeButton, fastForwardButton;

    public void OnCancelClick() {
        Debug.Log("Click!");
        ManagerScript.Instance.ClearObjects();
    }
}
