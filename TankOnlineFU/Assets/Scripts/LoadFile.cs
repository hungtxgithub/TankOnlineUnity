using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    private static LoadFile instance;
    public static LoadFile Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<LoadFile>();
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
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void LoadConstructionMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // SaveFile.Instance.
    }
}
