using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour
{
 private GameObject Player;
    private bool On_off;

    // Start is called before the first frame update
    void Start()
    {
    Player = GameObject.FindWithTag("Player");
    On_off = true;
    }

    // Update is called once per frame
    void Update()
    {
    if(Player.transform.position.z-1f >= transform.position.z)
    {
    if(On_off == true)
    {
    On_off = false;
    }
    Destroy(gameObject);

    }
    }
}
