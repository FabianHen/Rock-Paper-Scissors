using UnityEngine;

public class CreatorScript : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;

    private void Awake() {
        GameObject  gameController = GameObject.FindWithTag("Options");

        if (gameController == null) { 
            gameController = soundManager;
            Instantiate(gameController, soundManager.transform.position, soundManager.transform.rotation);
        }
    }
}
