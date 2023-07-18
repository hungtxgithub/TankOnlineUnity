using Assets.Scripts;
using Newtonsoft.Json;
using System;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public void SetTank(string s)
    {
        var type = GetTankType(s);
        var tanks = Common.GetTankFromJson();
        if (tanks.TankOwned.Contains(Convert.ToInt32(type)))
        {
            Logger.Info($"Selected {type} tank");
            var jsonData = JsonConvert.SerializeObject(new { tanks.TankOwned, TankSelected = Convert.ToInt32(type) }, Formatting.Indented);
            Common.InsertTankToJson(jsonData);
        } else
        {
            BuyTank(type);
        }
    }

    public void BuyTank(TankType type)
    {
        var tankPrice = GetTankPrice(type);
        if (type == TankType.GoldenTank)
        {
            var diamonObj = Common.GetDiamonFromJson();
            var diamonUserID = diamonObj.UserID;
            var diamon = diamonObj.Diamond;


            if (diamon >= tankPrice*1000)
            {
                var diamonNewValue = diamonObj.Diamond - tankPrice*1000;
                var jsonData = JsonConvert.SerializeObject(new { UserID = diamonUserID, Diamond = diamonNewValue }, Formatting.Indented);
                Common.InsertDiamonToJson(jsonData);
                Common.ShowDiamonToUI();

                var tank = Common.GetTankFromJson();
                tank.TankOwned.Add(Convert.ToInt32(TankType.GoldenTank));

                var tanks = Common.GetTankFromJson();
                tanks.TankOwned.Add(Convert.ToInt32(type));
                var jsonTank = JsonConvert.SerializeObject(new { tanks.TankOwned, tanks.TankSelected }, Formatting.Indented);
                Common.InsertTankToJson(jsonTank);

                Common.ShowTank(type);
                Logger.Info($"BuyTank success!");
            }
            else
            {
                Logger.Info($"Not enough diamon {diamon}");
            }
        }
        else
        {
            var goldObj = Common.GetGoldFromJson();
            var gold = goldObj.Gold;

            if (gold >= tankPrice)
            {
                var goldNewValue = goldObj.Gold - tankPrice;
                var jsonData = JsonConvert.SerializeObject(new { Gold = goldNewValue }, Formatting.Indented);
                Common.InsertGoldToJson(jsonData);
                Common.ShowGoldToUI();

                var tank = Common.GetTankFromJson();
                tank.TankOwned.Add(Convert.ToInt32(TankType.GoldenTank));

                var tanks = Common.GetTankFromJson();
                tanks.TankOwned.Add(Convert.ToInt32(type));
                var jsonTank = JsonConvert.SerializeObject(new { tanks.TankOwned, tanks.TankSelected }, Formatting.Indented);
                Common.InsertTankToJson(jsonTank);

                Common.ShowTank(type);
                Logger.Info($"BuyTank success!");
                //inventory.AddTank(type);
            }
            else
            {
                Logger.Info($"Not enough gold {gold}");
            }
        }
    }

    public static int GetTankPrice(TankType type)
    {
        if (type == TankType.T90) return 100;
        if (type == TankType.LazeTank) return 300;
        if (type == TankType.GoldenTank) return 99;
        return 0;
    }

    public static TankType GetTankType(string s)
    {
        if (s == TankType.Default.ToString()) return TankType.Default;
        if (s == TankType.T90.ToString()) return TankType.T90;
        if (s == TankType.LazeTank.ToString()) return TankType.LazeTank;
        if (s == TankType.GoldenTank.ToString()) return TankType.GoldenTank;
        return TankType.Default;
    }
}
