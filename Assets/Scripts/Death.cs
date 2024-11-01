using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float speed = 5f;  // オブジェクトの飛ぶ速さ
    private Rigidbody rb;

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        // オブジェクトをまっすぐ飛ばす
        rb.linearVelocity = transform.forward * speed;
    }
    void OnTriggerEnter(Collider other)
    {
     if(other.transform.tag == "wall")
     {
     Destroy(gameObject);
     }   
    }
}
