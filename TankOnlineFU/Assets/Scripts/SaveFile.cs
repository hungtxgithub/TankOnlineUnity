using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using Unity.VisualScripting;
using System.Linq;

public class SaveFile : MonoBehaviour
{
    private static SaveFile instance;

    private Dictionary<string, List<MapData>> dic = new Dictionary<string, List<MapData>>();


    public static SaveFile Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<SaveFile>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Save file
    public void saveFileGold(int gold)
    {
        string json = JsonConvert.SerializeObject(gold);
        File.WriteAllText("Assets/Gold.json", json);
    }

    // Save file
    public void saveFile(string keySave, List<MapData> ls)
    {
        if(dic.ContainsKey(keySave))
        {
            dic[keySave] = ls;
        } else
        {
            dic.Add(keySave, ls);
        }

        string json = JsonConvert.SerializeObject(dic);
        File.WriteAllText("Assets/SaveFile.json", json);
    }

    // Load file
    public List<MapData> loadFile()
    {
        string json = File.ReadAllText("Assets/SaveFile.json");
        dic = JsonConvert.DeserializeObject<Dictionary<string, List<MapData>>>(json);

        return dic["Map"];
    }


}
