using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Assets.Scripts.TopUpDiamond
{
    public class ContentTopUp
    {
        const string FILE_SAVE_DIAMOND = "Assets/Scripts/TopUpDiamond/Diamond.json";

        public string GetContentTopUp()
        {
            var diamon = File.ReadAllText("Assets/Scripts/TopUpDiamond/Diamond.json");
            var diamonObj = JsonConvert.DeserializeObject<DiamonModel>(diamon);
            var diamonUserID = diamonObj.UserID;
            var diamonValue = diamonObj.Diamond;

            if (diamonUserID == "")
            {
                var userID = MD5Hash(Guid.NewGuid().ToString());
                var jsonData = JsonConvert.SerializeObject(new { UserID = userID, Diamond = diamonValue }, Formatting.Indented);
                File.WriteAllText(FILE_SAVE_DIAMOND, jsonData);
                return userID;
            }

            return diamonUserID;
        }

        private static string MD5Hash(string input)
        {
            StringBuilder hash = new();
            MD5CryptoServiceProvider md5provider = new();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
