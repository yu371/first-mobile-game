
using TMPro;
using UnityEngine;

public class information_set : MonoBehaviour
{
    public TextMeshProUGUI Rank_text;
    public TextMeshProUGUI Name_text;
    public TextMeshProUGUI Score_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set(int Rank,string Name,long Score)
    {
    Rank_text.text = Rank.ToString() + "位";
    Name_text.text = Name.ToString()+"様";
    Score_text.text = Score.ToString()+"点";

    }
}
