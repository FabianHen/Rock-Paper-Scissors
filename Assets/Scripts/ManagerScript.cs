using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    Paused,
    Running,
    FastForward
}
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
    private bool objectsPlaceable = true;
    public GameObject rock, paper, scissors;
    public GameStatus status;
    public float normalSpeed, fastForwardSpeed;
    public bool destroyOnHit;
    private void Start() {
        status = GameStatus.Paused;
        objectsPlaceable = SceneManager.GetActiveScene().buildIndex != 0;
        destroyOnHit = true;
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0) && objectsPlaceable) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1000.0f;       
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(GetCurrentObject(), objectPos, Quaternion.identity); ;
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
    public bool OneLeft() {
        Type winnerType = Objects[0].type;
        foreach(ObjectScript obj in Objects) {
            if(obj.type != winnerType) { 
                return false;
            }
        }
        return true;
    }
    public void SetObjectsPlaceable(Boolean pObjectsPlaceable) { objectsPlaceable = pObjectsPlaceable; }
    public void SetCurrentType(Type type) { currentType = type;}

    public Boolean GetObjectsPlaceable() { return objectsPlaceable; }
    public Type GetCurrentType() { return currentType;}
}
 