using UnityEngine;
using UnityEngine.UI;

public class CancelButtonScript : MonoBehaviour
{
    private void Update() {
        gameObject.GetComponent<Button>().interactable = ManagerScript.Instance.status == GameStatus.Paused;
    }
    public void OnCancelClick() {
        ManagerScript.Instance.ClearObjects();
    }  
}

