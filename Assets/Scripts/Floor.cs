using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject Player;
 
 
    // Start is called before the first frame update
    void Start()
    {
    Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = new Vector3(transform.position.x,transform.position.y,Player.transform.position.z);
    }
}
