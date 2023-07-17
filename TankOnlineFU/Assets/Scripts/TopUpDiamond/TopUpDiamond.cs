using CheckBotRecharge.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Text;
using UnityEngine;
using System.Linq;
using System.IO;
using Assets.Scripts.TopUpDiamond.Models;

public class TopUpDiamond
{
    const string SECRET_KEY = "ADMIN";
    const string FILE_SAVE_DIAMOND = "Assets/Scripts/TopUpDiamond/Diamond.json";

    public TopUpDiamond()
    {
        string content = GetAllHistoryTransaction();
        var historyTransactions = JsonConvert.DeserializeObject<TransactionResponseAPI>(content)?.ListHistoryTransaction;
        if (historyTransactions != null)
        {
            //Gọi API GetAllTransactionID
            List<string> listTransactionID = GetAllTransactionID();
            foreach (var item in historyTransactions)
            {
                //Chỉ xét trường hợp giao dịch có nội dung hợp lệ (nội dung phải == UserID ứng dụng) và chưa có trong DB
                if (CheckValidContent(item.TransactionContent, out string md5Hash) && listTransactionID.Any(x => x == item.TransactionID) == false)
                {
                    TransactionInsertRequest request = new TransactionInsertRequest()
                    {
                        SecretKey = SECRET_KEY,
                        Money = float.Parse(item.Money),
                        TransactionContent = item.TransactionContent,
                        TransactionTime = ConvertSringToDateTime(item.TransactionTime, "dd/MM/yyyy"),
                        UserID = md5Hash
                    };
                    InsertTransaction(request);

                    var diamon = File.ReadAllText("Assets/Scripts/TopUpDiamond/Diamond.json");

                    var diamonObj = JsonConvert.DeserializeObject<DiamonModel>(diamon);
                    var diamonUserID = diamonObj.UserID;
                    var diamonNewValue = diamonObj.Diamond + request.Money;

                    var jsonData = JsonConvert.SerializeObject(new { UserID = diamonUserID, Diamond = diamonNewValue }, Formatting.Indented);
                    File.WriteAllText(FILE_SAVE_DIAMOND, jsonData);
                }
            }
        }
    }

    string GetAllHistoryTransaction()
    {
        var client = new HttpClient();
        var response = client.GetAsync("https://api.thanhtoan247.xyz/api/PRU221mControllers/GetAllHistoryTransaction?SecretKey=" + SECRET_KEY).Result;
        var jsonString = response.Content.ReadAsStringAsync().Result;

        return jsonString;
    }

    List<string> GetAllTransactionID()
    {
        var client = new HttpClient();
        var response = client.GetAsync("https://api.thanhtoan247.xyz/api/PRU221mControllers/GetAllTransactionID?SecretKey=" + SECRET_KEY).Result;
        var jsonString = response.Content.ReadAsStringAsync().Result;

        return JsonConvert.DeserializeObject<List<string>>(jsonString);
    }

    string InsertTransaction(TransactionInsertRequest requestData)
    {
        var apiUrl = "https://api.thanhtoan247.xyz/api/PRU221mControllers/InsertTransaction";
        var client = new HttpClient();

        var requestContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

        //client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        //client.DefaultRequestHeaders.Add("Authorization", "admin");

        var response = client.PostAsync(apiUrl, requestContent).Result;

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            return responseContent;
        }
        else
        {
            throw new Exception($"Request failed: {response.StatusCode}");
        }
    }

    bool CheckValidContent(string content, out string md5Hash)
    {
        md5Hash = "";
        var match = Regex.Match(content, @"[a-fA-F0-9]{32}$");

        bool check = false;

        if (match.Success)
        {
            var diamon = File.ReadAllText("Assets/Scripts/TopUpDiamond/Diamond.json");
            var diamonObj = JsonConvert.DeserializeObject<DiamonModel>(diamon);
            var diamonUserID = diamonObj.UserID;
            var contentValue = match.Value;

            //Nếu nội dung chuyển khoản == UserID của ứng dụng
            if (contentValue == diamonUserID)
            {
                md5Hash = contentValue;
                check = true;
            }
        }
        return check;
    }

    DateTime ConvertSringToDateTime(string datetime, string pattern)
    {
        DateTime result = DateTime.ParseExact(datetime, pattern, CultureInfo.InvariantCulture);
        return result;
    }
}
