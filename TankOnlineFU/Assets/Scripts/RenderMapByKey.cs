using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

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

            //positionRender.x = TankController.Instance.getTank().Position.x - 0.18f;
            //positionRender.y = TankController.Instance.getTank().Position.y + 0.04f;
            //positionRender.z = TankController.Instance.getTank().Position.z;

            if (checkExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(checkExitsMap(TankController.Instance.getTank().Position));

                typeBrick = getTypeOfMap(checkExitsMap(TankController.Instance.getTank().Position));
            }
            else
            {

                typeBrick = 0;

            }


            Instantiate(gameObjectBrick[typeBrick], TankController.Instance.getTank().Position, Quaternion.identity);

            typeBrick++;

            if (typeBrick == gameObjectBrick.Count())
            {
                typeBrick = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //positionRender.x = TankController.Instance.getTank().Position.x - 0.18f;
            //positionRender.y = TankController.Instance.getTank().Position.y + 0.04f;
            //positionRender.z = TankController.Instance.getTank().Position.z;

            if (checkExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(checkExitsMap(TankController.Instance.getTank().Position));

                typeStone = getTypeOfMap(checkExitsMap(TankController.Instance.getTank().Position));
            }
            else
            {

                typeStone = 0;

            }


            Instantiate(gameObjectStone[typeStone], TankController.Instance.getTank().Position, Quaternion.identity);

            typeStone++;

            if (typeStone == gameObjectStone.Count())
            {
                typeStone = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (checkExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(checkExitsMap(TankController.Instance.getTank().Position));

            }

            Instantiate(gameObjectStrees, TankController.Instance.getTank().Position, Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (checkExitsMap(TankController.Instance.getTank().Position) != null)
            {
                GameObject.Destroy(checkExitsMap(TankController.Instance.getTank().Position));

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
    }

    public GameObject checkExitsMap(Vector3 position)
    {

        List<GameObject> ls = GameObject.FindGameObjectsWithTag("Map").ToList();

        // case Position change with Brick and Stone

        if (ls.Count() > 0)
        {
            // If exit map
            if (ls.Where(x => x.transform.position == position) != null)
            {
                GameObject mapGame = ls.Where(x => x.transform.position == position).FirstOrDefault();
                return mapGame;
            }
        }
        return null;
    }

    public int getTypeOfMap(GameObject gObj)
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

}
