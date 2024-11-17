using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON; // SimpleJSON ライブラリを使用
using TMPro;
using Newtonsoft.Json;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public GameObject Scorebanner;
    private string url = "https://script.google.com/macros/s/AKfycbwb4Cxm7YnPUMzuINxBJAoHwxryFJNxb8ylsOPPkgT0c6tP4xJ7FvQkHht3qFW9K3sp/exec"; 
    // public TextMeshProUGUI textMeshProUGUI;
    public GameObject Scroll_context;

    void Start()
    {

        GetRanking();
    }


    public void AddScore(string username, int score)
    {
        StartCoroutine(PostScore(username, score));
    }

    public void GetRanking()
    {
        StartCoroutine(GetRankingCoroutine());
    }

    private IEnumerator PostScore(string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("action", "addScore");
        form.AddField("username", username);
        form.AddField("score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Score Added Successfully: " + www.downloadHandler.text);
            }
        }
    }

  private IEnumerator GetRankingCoroutine()
{
    WWWForm form = new WWWForm();
    form.AddField("action", "getRanking");

    using (UnityWebRequest www = UnityWebRequest.Post(url, form))
    {
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            Debug.Log(jsonResult);
            String_to_List(jsonResult);

        }
    }
}
public void String_to_List(string jsonString)
{
    try
    {
        // JSONをList<List<object>>としてデシリアライズする
        List<List<object>> list = JsonConvert.DeserializeObject<List<List<object>>>(jsonString);

        // 名前ごとにスコアが高いものを保持する辞書を作成
        Dictionary<string, long> nameScoreDict = new Dictionary<string, long>();

        foreach (var innerList in list)
        {
            if (innerList.Count == 2 && innerList[0] is string name && innerList[1] is long score)
            {
                // 名前がすでに辞書に存在する場合はスコアを比較して高い方を保持
                if (nameScoreDict.ContainsKey(name))
                {
                    if (score > nameScoreDict[name])
                    {
                        nameScoreDict[name] = score; // 高いスコアに更新
                    }
                }
                else
                {
                    nameScoreDict[name] = score; // 新しい名前を追加
                }
            }
            else
            {
                Debug.LogWarning("無効なデータ形式が含まれています。");
            }
        }

        // 順位を付けてスコアの降順にソートして出力
        int rank = 1;
        // textMeshProUGUI.text = "";
        Vector3 banner_poj = new Vector3(0,0,0); 
               foreach (var kvp in nameScoreDict.OrderByDescending(pair => pair.Value))
        {

            // textMeshProUGUI.text += $"{rank}位: {kvp.Key}: {kvp.Value}\n";
            GameObject Banner = Instantiate(Scorebanner,new Vector3(banner_poj.x,banner_poj.y+ 20 -rank*20,banner_poj.z),Quaternion.identity,Scroll_context.transform.parent);
            Banner.transform.localPosition = new Vector3(banner_poj.x+100,banner_poj.y -rank*20,banner_poj.z);
            Banner.GetComponent<information_set>().Set(rank,kvp.Key,kvp.Value);
            rank++;
        }
    }
    catch (JsonSerializationException ex)
    {
        Debug.LogError("JSONのデシリアライズ中にエラーが発生しました: " + ex.Message);
    }
    catch (System.Exception ex)
    {
        Debug.LogError("予期しないエラーが発生しました: " + ex.Message);
    }
}


}
