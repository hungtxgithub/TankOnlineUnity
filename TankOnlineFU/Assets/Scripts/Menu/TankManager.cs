using System.Collections;
using System.Collections.Generic;
using TMPro;
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
       
        var money = inventory.Money;
        var tankPrice = GetTankPrice(type);
        if (money >= tankPrice)
        {
            inventory.Money += -tankPrice;
            inventory.AddTank(type);
        }
        else
        {
            Logger.Info($"Not enough money {money}");
        }
    }

    public static int GetTankPrice(TankType type)
    {
        if (type == TankType.T90) return 20;
        if (type == TankType.LazeTank) return 100;
        if (type == TankType.GoldenTank) return 500;
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
