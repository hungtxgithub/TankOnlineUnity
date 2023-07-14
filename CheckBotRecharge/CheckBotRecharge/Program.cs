using CheckBotRecharge.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

string HistoryFilePath = GetAppSettings("HistoryFilePath");
string SECRET_KEY = GetAppSettings("SECRET_KEY");

HttpClient client = new();

while (true)
{
    string content = File.ReadAllText(HistoryFilePath);
    var historyTransactions = JsonConvert.DeserializeObject<TransactionResponseAPI>(content)?.ListHistoryTransaction;
    if (historyTransactions != null)
    {
        //Gọi API GetAllTransactionID
        List<string> listTransactionID = GetAllTransactionID();
        foreach (var item in historyTransactions)
        {
            //Chỉ xét trường hợp giao dịch có nội dung hợp lệ (Chứa md5Hash) và chưa có trong DB
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
                var resInsert = InsertTransaction(request);
            }
        }
    }
    Thread.Sleep(3000);
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

    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
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
    bool check = match.Success;
    if (check)
        md5Hash = match.Value;
    return check;
}

DateTime ConvertSringToDateTime(string datetime, string pattern)
{
    DateTime result = DateTime.ParseExact(datetime, pattern, CultureInfo.InvariantCulture);
    return result;
}

static string GetAppSettings(string key)
{
    return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()[key];
}