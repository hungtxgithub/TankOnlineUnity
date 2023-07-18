//using Assets.Scripts;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory
//{
//    public TankType SelectedTank;
//    public List<TankType> AvailableTank = new List<TankType>();

//    private static Inventory instance;

//    public static Inventory GetInstance()
//    {
//        if (instance == null)
//        {
//            instance = new Inventory();
//        }
//        return instance;
//    }

//    private Inventory()
//    {
//        var tank = Common.GetTankFromJson();

//        SelectedTank = TankManager.GetTankType(tank.TankSelected.ToString());
//        foreach (var item in tank.TankOwned)
//        {
//            AvailableTank.Add(TankManager.GetTankType(item.ToString()));
//        }
//    }
//}
