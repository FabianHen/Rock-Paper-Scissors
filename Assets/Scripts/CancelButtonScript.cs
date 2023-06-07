using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CancelButtonScript : MonoBehaviour
{
    private AudioSource sound;

    void Start() {
        sound = GetComponent<AudioSource>();
    }
    private void Update() {
        gameObject.GetComponent<Button>().interactable = ManagerScript.Instance.status == GameStatus.Paused;
    }
    public void OnCancelClick() {
        sound.Play();
        ManagerScript.Instance.ClearObjects();
    }  
}

