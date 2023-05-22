using UnityEngine;

public class SpawnRandomObjects : MonoBehaviour
{
    [SerializeField] GameObject rock, paper, scissors;
    private GameObject[] objects;
    private float cooldown;
    private int objectCount;
    [SerializeField] float spawnBuffer;
    void Start()
    {
        objects = new GameObject[3];
        objects[0] = rock;
        objects[1] = paper;
        objects[2] = scissors;

        SpawnObject(0);
        SpawnObject(1);
        SpawnObject(2);

        cooldown = Time.time + spawnBuffer;

        objectCount = 0;

    }
    void Update()
    {
        if( Time.time > cooldown && ManagerScript.Instance.Objects.Count < 10) {
            SpawnObject(objectCount);
            cooldown = Time.time + spawnBuffer;
            objectCount++;
            if(objectCount > 2) {
                objectCount = 0;
            }

        }   
        else if(ManagerScript.Instance.Objects.Count >= 10 && ManagerScript.Instance.OneLeft()) {
            ManagerScript.Instance.ClearObjects();
        }
    }

    private void SpawnObject(int index) {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(objects[index], spawnPosition, Quaternion.identity);
    }
    
}
