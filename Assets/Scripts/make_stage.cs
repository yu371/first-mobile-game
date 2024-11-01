using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_stage : MonoBehaviour
{
    public GameObject ashiba; 
    public GameObject Wall;
    private Vector3 ashiba_position;
    private GameObject Player;
    private CameraController cameraController;
    private float NewY;

    // Start is called before the first frame update
    void Start()
    {
        ashiba_position = new Vector3(0, 0, 0);
        Make();
        Player = GameObject.FindWithTag("MainCamera");
        cameraController = Player.GetComponent<CameraController>();
        // NewY = cameraController.newY;

    }

    // Update is called once per frame
    void Update()
    {
    for(int i = 0; i <=3 ;i++)
    {
    Make();
    }
    if(NewY % 3 == 0)
    {
    Make();
    }
    }

    void Make()
    {
        ashiba_position = new Vector3(ashiba_position.x, ashiba_position.y + 3, ashiba_position.z);
        CreateAshiba(ashiba_position.x, 6, 0.5f);   
    }

    // 足場を生成する関数
    void CreateAshiba(float xPos, float width, float height)
    {
        GameObject a = Instantiate(ashiba, new Vector3(xPos, ashiba_position.y, ashiba_position.z), Quaternion.identity);
        a.transform.localScale = new Vector3(width, height, 1);
    }
}
