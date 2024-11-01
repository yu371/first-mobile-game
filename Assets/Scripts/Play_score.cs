using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Play_score : MonoBehaviour
{
    private Scoreboard scoreboard;
    private TextMeshProUGUI text;
    void Start()
    {
    scoreboard = GameObject.FindWithTag("score").GetComponent<Scoreboard>();
    text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
    text.text = scoreboard.score.ToString();
    }
}
