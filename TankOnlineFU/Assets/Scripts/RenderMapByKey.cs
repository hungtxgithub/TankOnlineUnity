using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMapByKey : MonoBehaviour
{

    private static RenderMapByKey instance;
    public static RenderMapByKey Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<RenderMapByKey>();
            }
            return instance;
        }
    }

    [SerializeField]
    public GameObject gameObjectBrick;

    [SerializeField]
    public GameObject gameObjectStone;

    [SerializeField]
    public GameObject gameObjectStrees;

    [SerializeField]
    public GameObject gameObjectWater;

    private MapData brick;
    private MapData stone;
    private MapData strees;
    private MapData water;


    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        brick = new MapData { keyCap = 1, mapValue = gameObjectBrick };
        stone = new MapData { keyCap = 2, mapValue = gameObjectStone };
        strees = new MapData { keyCap = 3, mapValue = gameObjectStrees };
        water = new MapData { keyCap = 4, mapValue = gameObjectWater };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(gameObjectBrick, TankController.Instance.getTank().Position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(gameObjectStone, TankController.Instance.getTank().Position, Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(gameObjectStrees, TankController.Instance.getTank().Position, Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(gameObjectWater, TankController.Instance.getTank().Position, Quaternion.identity);
        }
    }
}
