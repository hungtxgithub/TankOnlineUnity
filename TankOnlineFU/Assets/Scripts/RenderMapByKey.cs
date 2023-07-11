using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    public List<GameObject> gameObjectBrick;

    [SerializeField]
    public List<GameObject> gameObjectStone;

    [SerializeField]
    public GameObject gameObjectStrees;

    [SerializeField]
    public GameObject gameObjectWater;

    private MapData brick;
    private MapData stone;
    private MapData strees;
    private MapData water;

    private int typeBrick = 0;
    private int typeStone = 0;

    private GameObject GObjBrick;
    private GameObject GObjStone;

    List<MapData> lstBsSave = new List<MapData>();

    private Vector3 positionRender = new Vector3();


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //brick = new MapData { keyCap = 1, mapValue = gameObjectBrick };
        //stone = new MapData { keyCap = 2, mapValue = gameObjectStone };
        //strees = new MapData { keyCap = 3, mapValue = gameObjectStrees };
        //water = new MapData { keyCap = 4, mapValue = gameObjectWater };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            positionRender.x = TankController.Instance.getTank().Position.x - 0.218f;
            positionRender.y = TankController.Instance.getTank().Position.y - 0.255f;
            positionRender.z = TankController.Instance.getTank().Position.z;

            if (CheckExitsMap(positionRender) != null)
            {
                GameObject.Destroy(CheckExitsMap(positionRender));

                typeBrick = GetTypeOfMap(CheckExitsMap(positionRender));
            }
            else
            {

                typeBrick = 0;

            }


            Instantiate(gameObjectBrick[typeBrick], positionRender, Quaternion.identity);

            typeBrick++;

            if (typeBrick == gameObjectBrick.Count())
            {
                typeBrick = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            positionRender.x = TankController.Instance.getTank().Position.x - 0.218f;
            positionRender.y = TankController.Instance.getTank().Position.y - 0.255f;
            positionRender.z = TankController.Instance.getTank().Position.z;

            if (CheckExitsMap(positionRender) != null)
            {
                GameObject.Destroy(CheckExitsMap(positionRender));

                typeStone = GetTypeOfMap(CheckExitsMap(positionRender));
            }
            else
            {

                typeStone = 0;

            }


            Instantiate(gameObjectStone[typeStone], positionRender, Quaternion.identity);

            typeStone++;

            if (typeStone == gameObjectStone.Count())
            {
                typeStone = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CheckExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(CheckExitsMap(TankController.Instance.getTank().Position));

            }

            Instantiate(gameObjectStrees, TankController.Instance.getTank().Position, Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (CheckExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(CheckExitsMap(TankController.Instance.getTank().Position));

            }

            Instantiate(gameObjectWater, TankController.Instance.getTank().Position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            var mapLs = GameObject.FindGameObjectsWithTag("Map");

            foreach (var map in mapLs)
            {
                lstBsSave.Add(new MapData()
                {
                    objectType = map.name.Replace("(Clone)", ""),
                    positionX = map.transform.position.x,
                    positionY = map.transform.position.y
                });
            }

            SaveFile.Instance.saveFile("Map", lstBsSave);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (CheckExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(CheckExitsMap(TankController.Instance.getTank().Position));

            }
        }
    }

    public GameObject CheckExitsMap(Vector3 position)
    {

        List<GameObject> ls = GameObject.FindGameObjectsWithTag("Map").ToList();

        // case Position change with Brick and Stone
        Vector3 vt3 = new Vector3(position.x - 0.218f, position.y - 0.255f, position.z);

        Vector3 vt1 = new Vector3(position.x + 0.218f, position.y + 0.255f, position.z);

        if (ls.Count() > 0)
        {
            foreach (GameObject obj in ls)
            {
                if (obj.transform.position == position || obj.transform.position == vt3 || obj.transform.position == vt1)
                {
                    GameObject mapGame = obj;
                    return mapGame;
                }
            }
        }
        return null;
    }

    public int GetTypeOfMap(GameObject gObj)
    {
        try
        {
            string name = gObj.name.Replace("(Clone)", "");

            int type = int.Parse(name.Substring(name.Length - 1));

            switch (type)
            {
                case 1: return 1;
                case 2: return 2;
                case 3: return 0;
                default: return 0;
            }
        }
        catch (Exception e)
        {
            Logger.Info(e.Message);
            return 0;
        }

    }

}
