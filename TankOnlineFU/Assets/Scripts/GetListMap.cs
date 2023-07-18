using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GetListMap : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObjectMaps;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        float y = 700f;
        foreach (var map in SaveFile.Instance.loadListKeys())
        {
            GameObject child = Instantiate(gameObjectMaps, new Vector2(0, y), Quaternion.identity);

            child.transform.SetParent(parent);
            child.transform.position = new Vector2(960, y);
            y = y - 75;
            child.GetComponentInChildren<GameObject>().GetComponentInChildren<Text>().text=  map;
            //Button btn = child.GetComponentInChildren<Button>().onClick.AddListener(() => ButtonClicked(42));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
