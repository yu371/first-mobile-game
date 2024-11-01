using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreboard : MonoBehaviour
{
    public int score;
    private int past_score;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI past_scoretext;

    // Start is called before the first frame update
    void Start()
    {
    past_score = PlayerPrefs.GetInt("Score",0);
    if(past_score == 0)
    {
     past_scoretext.text="";
    }
    if(PlayerPrefs.GetInt("HighScore",0) != 0)
    {
    past_scoretext.text = "Score"+past_score.ToString();
    textMeshProUGUI.text = "HighScore" +PlayerPrefs.GetInt("HighScore",0).ToString(); 
    }
    else
    {
        textMeshProUGUI.text = "";
    }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ScoreAdd()
    {
    score += 1;
    }
    public void GameFinish()
    {
    PlayerPrefs.SetInt("Score",score);
    if(PlayerPrefs.GetInt("HighScore",0) <= score)
    {
      PlayerPrefs.SetInt("HighScore",score);
    }
    }
}
