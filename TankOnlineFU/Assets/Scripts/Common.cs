using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

namespace Assets.Scripts
{
    public class Common
    {
        public static DiamonModel GetDiamonFromJson()
        {
            var diamonFile = File.ReadAllText(Constant.FILE_SAVE_DIAMOND);
            return JsonConvert.DeserializeObject<DiamonModel>(diamonFile);
        }

        public static void InsertDiamonToJson(string jsonData)
        {
            File.WriteAllText(Constant.FILE_SAVE_DIAMOND, jsonData);
        }

        public static GoldModel GetGoldFromJson()
        {
            var goldFile = File.ReadAllText(Constant.FILE_SAVE_GOLD);
            return JsonConvert.DeserializeObject<GoldModel>(goldFile);
        }

        public static void InsertGoldToJson(string jsonData)
        {
            File.WriteAllText(Constant.FILE_SAVE_GOLD, jsonData);
        }

        public static TankModel GetTankFromJson()
        {
            var tankFile = File.ReadAllText(Constant.FILE_SAVE_TANK);
            return JsonConvert.DeserializeObject<TankModel>(tankFile);
        }

        public static void InsertTankToJson(string jsonData)
        {
            File.WriteAllText(Constant.FILE_SAVE_TANK, jsonData);
        }

        public static void ShowDiamonToUI()
        {
            var diamonObj = GetDiamonFromJson();
            GameObject.Find("DiamondValue").GetComponent<TextMeshProUGUI>().text = (diamonObj.Diamond / 1000).ToString().Split(".")[0];
        }

        public static void ShowGoldToUI()
        {
            var goldObj = GetGoldFromJson();
            GameObject.Find("GoldValue").GetComponent<TextMeshProUGUI>().text = goldObj.Gold.ToString();
        }

        public static void ShowTankShop()
        {
            var tank = GetTankFromJson();
            if (tank.TankOwned.Count > 0)
            {
                foreach (var itemOwned in tank.TankOwned)
                {
                    if (itemOwned == Convert.ToInt32(TankType.T90))
                    {
                        GameObject.FindGameObjectWithTag("TankOwned1").SetActive(false);
                    }
                    else if (itemOwned == Convert.ToInt32(TankType.LazeTank))
                    {
                        GameObject.FindGameObjectWithTag("TankOwned2").SetActive(false);
                    }
                    else if (itemOwned == Convert.ToInt32(TankType.GoldenTank))
                    {
                        GameObject.FindGameObjectWithTag("TankOwned3").SetActive(false);
                    }
                }
            }
        }

        public static void ShowTank(TankType type)
        {
            if (type == TankType.T90)
            {
                GameObject.FindGameObjectWithTag("TankOwned1").SetActive(false);
            }
            else if (type == TankType.LazeTank)
            {
                GameObject.FindGameObjectWithTag("TankOwned2").SetActive(false);
            }
            else if (type == TankType.GoldenTank)
            {
                GameObject.FindGameObjectWithTag("TankOwned3").SetActive(false);
            }
        }

        //    public List<int> TankOwned { get; set; }
        //public int TankSelected { get; set; }
    }
}
