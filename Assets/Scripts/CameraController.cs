// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     public float newY;
//     private Transform Playerpos;
//     public float minY = 1.0f; // 最低のy座標を設定
//     private float highestY; // 最高地点を記録するための変数
//     private Transform objTransform; // オブジェクトのTransform

//     // Startメソッドは最初に1回だけ呼び出されます
//     void Start()
//     {
//         objTransform = transform; // 現在のオブジェクトのTransformを取得
//         highestY = objTransform.position.y; // 初期位置を最高地点として記録
//         Playerpos = GameObject.FindWithTag("Player").transform;
//     }

//     // Updateメソッドは毎フレーム呼び出されます
//     void Update()
//     {
//         TrackHighestPoint();
//           CameraControll();
//     }

//     // オブジェクトの最高地点を記録する関数
//     void TrackHighestPoint()
//     {
//         float currentY = objTransform.position.y;

//         // 現在のY座標がこれまでの最高地点より高ければ更新
//         if (currentY > highestY)
//         {
//             highestY = currentY;
//         }

//         // デバッグ用に現在の最高地点を出力
//         Debug.Log("最高地点: " + highestY);
//     }

//     // 最高地点を取得するための関数
//     public float GetHighestPoint()
//     {
//         return highestY;
//     }
 

//     void CameraControll()
//     {
//         newY = Playerpos.position.y + 1f;

//         // y座標がhighestYより下がらないようにする
//         if (newY < highestY)
//         {
//             newY = highestY;
//         }

//         transform.position = new Vector3(transform.position.x, newY, transform.position.z);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float newY;
    private Transform Playerpos;
    public float minY = 1.0f; // 最低のy座標を設定
    private float highestY; // 最高地点を記録するための変数
    private Transform objTransform; // オブジェクトのTransform

    // Startメソッドは最初に1回だけ呼び出されます
    void Start()
    {
        Playerpos = GameObject.FindWithTag("Player").transform;
    }

    // Updateメソッドは毎フレーム呼び出されます
    void Update()
    {
    transform.position = new Vector3(transform.position.x,transform.position.y,Playerpos.transform.position.z);
    
    }

}