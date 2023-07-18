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
        var type = TankManager.GetTankType(Common.GetTankFromJson().TankSelected);
        Logger.Info("-------: " + type);
        var tank = PlayerTank[(int)type];
        Logger.Info("-------: " + tank);
        GameObject.Instantiate<GameObject>(tank);
    }
}
