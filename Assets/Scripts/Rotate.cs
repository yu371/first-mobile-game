using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 360f; // 1秒で360度回転する速度
    private Rigidbody rb;
    private bool isRotating = false;
    private float rotateTimer = 0f;
    public float rotateDuration = 1f; // 1秒間回転

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // スペースキーが押されたら回転処理を開始
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            isRotating = true;  // 回転処理を開始
            rotateTimer = 0f;   // タイマーをリセット
        }

        // 回転中の場合
        if (isRotating)
        {
            rotateTimer += Time.deltaTime; // タイマーを進める

            // 1秒間回転処理
            if (rotateTimer < rotateDuration)
            {
                // Z軸に回転のトルクを加える
                rb.AddTorque(0f, 0f, rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            else
            {
                // 1秒経過後、回転を停止
                isRotating = false;
         
                rb.isKinematic = true;
            }
        }
    }
}
