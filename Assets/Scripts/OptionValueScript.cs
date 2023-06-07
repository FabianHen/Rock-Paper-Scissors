
using UnityEngine;

public class OptionValueScript : MonoBehaviour
{
    #region Singleton
    public static OptionValueScript Instance;

    private void Awake() {
        if (Instance != null) {
            Debug.Log("To many OptionManagers!");
            return;
        }
        Instance = this;
    }
    #endregion

    public float volume;

    private void Start() {
        volume = 1.0f;
        DontDestroyOnLoad(this);
    }
}
