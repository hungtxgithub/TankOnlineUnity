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

    private Dictionary<string, List<BaseSave>> dic = new Dictionary<string, List<BaseSave>>();

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
        if (!File.Exists(Application.dataPath + "/savefile.json"))
        {
            using (FileStream fs = File.Create(Application.dataPath + "/savefile.json")) { fs.Close(); }
        }
    }

    // Save file
    public void saveFile(string keySave, List<BaseSave> ls)
    {
        if(dic.ContainsKey(keySave))
        {
            dic[keySave] = ls;
        } else
        {
            dic.Add(keySave, ls);
        }

        string json = JsonConvert.SerializeObject(dic);
        File.WriteAllText("savefile.json", json);
    }

    // Load file
    public void loadFile()
    {
        string json = File.ReadAllText("savefile.json");
        dic = JsonConvert.DeserializeObject<Dictionary<string, List<BaseSave>>>(json);
    }
}
