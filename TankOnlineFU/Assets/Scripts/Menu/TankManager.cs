using Assets.Scripts;
using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    private readonly Inventory inventory = Inventory.GetInstance();

    public void SetTank(string s)
    {
        var type = GetTankType(s);
        var tanks = inventory.AvailableTank;
        if (tanks.Contains(type))
        {
            Logger.Info($"Selected {type} tank");
            inventory.SelectedTank = type;
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
                Common.InsertDiamonToJson(jsonData);
                Common.ShowGoldToUI();
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

    private TankType GetTankType(string s)
    {
        if (s == TankType.Default.ToString()) return TankType.Default;
        if (s == TankType.T90.ToString()) return TankType.T90;
        if (s == TankType.LazeTank.ToString()) return TankType.LazeTank;
        if (s == TankType.GoldenTank.ToString()) return TankType.GoldenTank;
        return TankType.Default;
    }
}
