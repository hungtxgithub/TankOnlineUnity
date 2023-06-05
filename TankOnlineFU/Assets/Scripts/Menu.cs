using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> gameObjectBrick;

    [SerializeField]
    public List<GameObject> gameObjectStone;

    [SerializeField]
    public GameObject gameObjectStrees;

    [SerializeField]
    public GameObject gameObjectWater;
    public void LoadConstructionMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMap()
    {

       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        // List<MapData> datas = SaveFile.Instance.loadFile();
        // foreach (MapData data in datas)
        // {
        //     switch (data.objectType)
        //     {
        //         case "Brick1":
        //             Instantiate(gameObjectBrick[0], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Brick2":
        //             Instantiate(gameObjectBrick[1], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Brick3":
        //             Instantiate(gameObjectBrick[2], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "BrickCell":
        //             Instantiate(gameObjectBrick[3], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Stone1":
        //             Instantiate(gameObjectStone[0], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Stone2":
        //             Instantiate(gameObjectStone[1], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Stone3":
        //             Instantiate(gameObjectStone[2], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "StoneCell":
        //             Instantiate(gameObjectStone[3], new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Trees":
        //             Instantiate(gameObjectStrees, new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //         case "Water":
        //             Instantiate(gameObjectWater, new Vector2(data.positionX, data.positionY), Quaternion.identity);
        //             break;
        //     }
        // }
    }
}
