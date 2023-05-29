using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Type
{
    Rock,
    Paper,
    Scissors
}
public class ObjectScript : MonoBehaviour
{
    public Type type;
    private Type targetType;
    [SerializeField] private List<ObjectScript> collidingObjects;
    public Sprite rockSprite, paperSprite, scissorsSprite;
    private float cooldown;
    void Start()
    {
        cooldown = Time.time + 1;
        collidingObjects = new List<ObjectScript>();
        ManagerScript.Instance.Objects.Add(this);
        targetType = SetTargetType(type);
    }
    void Update()
    {
        if (Time.time > cooldown) {
            CheckCollidingObjects();
        }
        if (SearchNearestTargetType() != null && ManagerScript.Instance.status != GameStatus.Paused) {
            Vector3 nearestTargetType = SearchNearestTargetType().transform.position;
            Vector3 targetPosition = Vector3.ClampMagnitude(nearestTargetType - transform.position, 0.1f);
            targetPosition.z = 0;
            if (ManagerScript.Instance.status == GameStatus.Running) {
                transform.position += targetPosition * ManagerScript.Instance.normalSpeed;
            }
            else {
                transform.position += targetPosition * ManagerScript.Instance.fastForwardSpeed;
            }
        }
    }

    private void UpdateSprite() {
        if (type == Type.Rock) { this.GetComponent<SpriteRenderer>().sprite = rockSprite; }
        else if (type == Type.Paper) { this.GetComponent<SpriteRenderer>().sprite = paperSprite; }
        else if (type == Type.Scissors) { this.GetComponent<SpriteRenderer>().sprite = scissorsSprite; }
    }

    private void CheckCollidingObjects() {
        if (collidingObjects != null) {
           for(int i = 0; i < collidingObjects.Count; i++) {
                if (collidingObjects[i].type == targetType) {
                    collidingObjects[i].Hit(type);
                }
            }
        }
    }

    private ObjectScript SearchNearestTargetType() {
        float distance = 50000.0f;
        ObjectScript nearestObject = null;
        foreach (var obj in ManagerScript.Instance.Objects) { 
            if (obj.type == targetType) {
                float distanceNew = Vector3.Distance(this.transform.position , obj.transform.position);
                if(distanceNew < distance) {
                    nearestObject = obj;
                    distance  = distanceNew;
                }
            } 
        }
        return nearestObject;
    }

    private Type SetTargetType(Type pType) {
        if(pType == Type.Paper) { return Type.Rock; }
        if(pType == Type.Scissors) { return Type.Paper; }
        return Type.Scissors;
    }

    public void Hit(Type pType) {
        if (!ManagerScript.Instance.destroyOnHit) {
            type = pType;
            targetType = SetTargetType(type);
            UpdateSprite();
            cooldown = Time.time + 1;
        }
        else {
            ManagerScript.Instance.Objects.Remove(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<ObjectScript>() != null) {
            var collisionObject = other.GetComponent<ObjectScript>();
            collidingObjects.Add(collisionObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        collidingObjects.Remove(other.GetComponent<ObjectScript>());
    }
}
