using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    int money = 0;
    public TankType SelectedTank;
    
    public List<TankType> availableTank = new List<TankType>() ;

    private static Inventory instance;

    public static Inventory GetInstance()
    {
        if (instance == null)
        {
            instance = new Inventory();
        }
        return instance;
    }

    private Inventory()
    {
        money = 1000;
        SelectedTank = TankType.T90;
        availableTank.Add(TankType.Default);
        availableTank.Add(TankType.T90);
        availableTank.Add(TankType.LazeTank);
    }

    public int Money
    {
        get { return money; }
    }

    public int AddMoney(int amount)
    {
        money += amount;
        if (money <= 0)
        {
            money = 0;
        }
        return money;
    }

    public void AddTank(TankType type)
    {
        if (!FindTank(type))
        {
            availableTank.Add(type);
        }
    }

    public bool FindTank(TankType tank)
    {
        return availableTank.Contains(tank);
    }
}
