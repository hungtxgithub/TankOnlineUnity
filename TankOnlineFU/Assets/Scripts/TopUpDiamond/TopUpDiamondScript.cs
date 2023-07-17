using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TopUpDiamondScript : MonoBehaviour
{

    void Start()
    {
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
