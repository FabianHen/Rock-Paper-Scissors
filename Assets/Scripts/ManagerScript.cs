using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Type currentType;
    private Boolean objectsPlaceable = true;
    public GameObject rock, paper, scissors; 

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && objectsPlaceable) {
            Instantiate(GetCurrentObject(),new Vector3(Input.mousePosition.x, Input.mousePosition.y,-2),new Quaternion(0,0,0,0));
        }
    }

    private GameObject GetCurrentObject() {
        if (currentType == Type.Rock) { return rock; }
        else if (currentType == Type.Paper) { return paper; }
        else { return scissors; }
    }

    public void ClearObjects() {
        foreach (ObjectScript obj in Objects) {
            Destroy(obj.GameObject());
        }
        Objects = new List<ObjectScript> ();
    }

    public void SetObjectsPlaceable(Boolean pObjectsPlaceable) { objectsPlaceable = pObjectsPlaceable; }
    public void SetCurrentType(Type type) { currentType = type;}

    public Boolean GetObjectsPlaceable() { return objectsPlaceable; }
    public Type GetCurrentType() { return currentType;}
}
 