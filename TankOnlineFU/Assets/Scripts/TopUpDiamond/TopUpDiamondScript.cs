using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TopUpDiamondScript : MonoBehaviour
{

    void Start()
    {
        var diamon = File.ReadAllText("Assets/Scripts/TopUpDiamond/Diamond.json");
        var diamonObj = JsonConvert.DeserializeObject<DiamonModel>(diamon);
        GameObject.Find("DiamondValue").GetComponent<TextMeshProUGUI>().text = (diamonObj.Diamond / 1000).ToString().Split(".")[0];

        var gold = File.ReadAllText("Assets/Gold.json");
        var goldObj = JsonConvert.DeserializeObject<GoldModel>(gold);
        GameObject.Find("GoldValue").GetComponent<TextMeshProUGUI>().text = goldObj.Gold.ToString();

        // Gọi phương thức chạy coroutine
        StartCoroutine(MyAsyncLoop());
    }

    // Coroutine để chạy vòng lặp bất đồng bộ
    IEnumerator MyAsyncLoop()
    {
        while (true)
        {
            // Chờ một khoảng thời gian nhất định
            yield return new WaitForSeconds(3.0f);

            // Kiểm tra điều kiện để thực thi
            if (IsInternetAvailable())
            {
                new RefreshTopUp();
            }
        }

    }

    IEnumerator CheckInternetConnection()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://www.google.com"))
        {
            // Thực hiện yêu cầu đến trang web "https://www.google.com"
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Kết nối internet khả dụng
                Debug.Log("Đã kết nối internet.");
            }
            else
            {
                // Kết nối internet không khả dụng
                Debug.Log("Không có kết nối internet.");
            }
        }
    }

    bool IsInternetAvailable()
    {
        try
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get("https://www.google.com"))
            {
                // Thực hiện yêu cầu đến trang web "https://www.google.com"
                webRequest.SendWebRequest();

                // Đợi cho đến khi yêu cầu hoàn thành
                while (!webRequest.isDone)
                {
                }

                // Kiểm tra kết quả yêu cầu
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Kết nối internet khả dụng
                    return true;
                }
                else
                {
                    // Kết nối internet không khả dụng
                    return false;
                }
            }
        }
        catch
        {
            // Nếu xảy ra lỗi trong quá trình kiểm tra kết nối
            return false;
        }
    }
}
