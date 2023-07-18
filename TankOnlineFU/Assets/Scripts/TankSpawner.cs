using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnerPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    public GameObject[] PlayerTank = new GameObject[4];

    private void SpawnerPlayer()
    {
        var tankFile = Common.GetTankFromJson();

        var type = TankManager.GetTankType(tankFile.TankSelected);
        var tank = PlayerTank[(int) type];
        GameObject.Instantiate<GameObject>(tank);
    }
}
