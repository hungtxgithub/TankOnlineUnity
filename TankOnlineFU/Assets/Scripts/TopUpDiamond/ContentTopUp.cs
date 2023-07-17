using Assets.Scripts.TopUpDiamond.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;

namespace Assets.Scripts.TopUpDiamond
{
    public class ContentTopUp
    {
        const string FILE_SAVE_DIAMOND = "Assets/Scripts/TopUpDiamond/Diamond.json";

        public void ShowContentTopUp()
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
                DownloadImageFromUrl(ConvertToQR(userID));
            }
            else
            {
                DownloadImageFromUrl(ConvertToQR(diamonUserID));
            }
        }

        private void DownloadImageFromUrl(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                // Tải dữ liệu hình ảnh từ URL
                byte[] imageData = client.DownloadData(imageUrl);

                // Lưu dữ liệu hình ảnh thành file .png
                System.IO.File.WriteAllBytes("Assets/Scripts/TopUpDiamond/VCB.png", imageData);
            }
        }

        private string ConvertToQR(string content)
        {
            return $"https://img.vietqr.io/image/VCB-0291000350547-compact.png?accountName=NGUYEN TRONG HUNG&addInfo={content}";
        }

        private IEnumerable ShowImageByUrl(string imageUrl)
        {
            // Tạo yêu cầu tải hình ảnh từ URL
            var www = new WWW(imageUrl);

            // Đợi đến khi tải xong hình ảnh
            yield return www;

            // Kiểm tra nếu có lỗi xảy ra
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("Lỗi khi tải hình ảnh từ URL: " + www.error);
            }
            else
            {
                // Tải hình ảnh thành công, chuyển đổi nó thành Sprite
                Texture2D texture = www.texture;
                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                // Tìm đối tượng có tag "image1Tag"
                GameObject imageObject = GameObject.FindGameObjectWithTag("ImageTopUp");

                // Kiểm tra nếu tìm thấy đối tượng và nó có thành phần Image
                if (imageObject != null)
                {
                    Image imageComponent = imageObject.GetComponent<Image>();
                    if (imageComponent != null)
                    {
                        // Thay đổi hình ảnh thành sprite mới
                        imageComponent.sprite = newSprite;
                    }
                }
            }
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
