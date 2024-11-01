using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_wall : MonoBehaviour
{
    private float z;
    public GameObject obj;
    public GameObject obj2;
    private float distance = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
    z = 30;
    }

    // Update is called once per frame
    void Update()
    {

    
    }
    public void Wall_make()
    {
    z += 10;
    int R = Random.Range(-4,4);
    Instantiate(obj,new Vector3(R-distance,1,z),Quaternion.identity);
    Instantiate(obj2,new Vector3(R+distance,1,z),Quaternion.identity);
    }
}
