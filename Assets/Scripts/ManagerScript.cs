using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    #region Singleton
    public static ManagerScript Instance;

    private void Awake() {
        if (Instance != null) {
            Debug.Log("To many Managers!");
            return;
        }
        Instance = this;
    }
    #endregion

    public List<ObjectScript> Objects = new();

    void Update() {
        CheckMousePosition();
        UpdateMouseIcon();

    }
}
 