using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public List<GameObject> RoomBorders;
    public GameObject doorPrefab, chestPrefab;
    public static bool hasKey;

    private void Start()
    {
        hasKey = false;
        SetupDoor();
        SetupChest();
    }

    private void SetupDoor()
    {
        int rnd = Random.Range(0, RoomBorders.Count);

        GameObject door = Instantiate(doorPrefab, RoomBorders[rnd].transform);
        door.transform.parent = GameObject.Find("Environment").transform;
        door.name = "Door";

        Destroy(RoomBorders[rnd]);
    }

    private void SetupChest()
    {
        int rndX = Random.Range(0, 6);
        int rndZ = Random.Range(0, 6);
        GameObject chest = Instantiate(chestPrefab, new Vector3(rndX, -.55f, rndZ), Quaternion.identity);
        chest.transform.parent = GameObject.Find("Environment").transform;
        chest.name = "chest";
    }

    private void Awake()
    {
        _instance = this;
    }
}
