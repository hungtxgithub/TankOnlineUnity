using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
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
    }
}
