using UnityEngine;
using System.IO;
using System.Collections;

public class ShareController : MonoBehaviour
{
    void Start()
    {
      
    }
    public void Share()
    {
        StartCoroutine(ShareCoroutine());
    }

    public IEnumerator ShareCoroutine()
    {
        const string fileName = "test.png";
        string imgPath = Path.Combine(Application.persistentDataPath, fileName);

        // 前回のデータを削除
        if (File.Exists(imgPath))
        {
            File.Delete(imgPath);
        }

        // スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot(imgPath);

        // 撮影画像の保存が完了するまで少し待機
        yield return new WaitForSeconds(0.5f);

        // 投稿する
        string tweetText = "sxrdcufvyg";
        string tweetURL = "";

        try
        {
            if(imgPath != null)
            {
                 SocialConnector.SocialConnector.Share(tweetText, tweetURL, imgPath);
            }
            
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
