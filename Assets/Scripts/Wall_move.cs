using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wall_move : MonoBehaviour
{
    private GameObject Player;
    private float player_high;
    // Start is called before the first frame update
    void Start()
    {
    Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     transform.position = new Vector3(transform.position.x,Player.transform.position.y,transform.position.z);   
    }
}
