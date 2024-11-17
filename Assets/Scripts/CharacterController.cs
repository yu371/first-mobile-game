
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterController : MonoBehaviour
{
  public float maxSpeed = 5f;  // オブジェクトの最大移動速度
    public float speedDamping = 0.01f;  // 移動速度の減衰速度
    private float swipeSpeed = 0f;  // スワイプの速さ
    private Vector2 startTouchPosition, endTouchPosition;  // スワイプ開始と終了の位置
    private Rigidbody rb;  // Rigidbodyへの参照
    private bool plus;
    private float swipeDistance;
    private bool minus;
    public bool Start_switch;
    public GameObject button;
    public GameObject ScoreText;
    public GameObject Death;
    private bool true_false;
    private AudioSource audioSource;
    private GameObject Score;
    private GameObject ADS;
    private InterstitialAdTest interstitialAdTest;
    
    public void Game_start()
    {
     Destroy(button);
     Invoke("Start_switch_True",0.1f); 
     interstitialAdTest.On_Off = true;
    }


    void Start_switch_True()
    {
       Start_switch = true;
    }
    void Start()
    {
        
        ADS = GameObject.FindWithTag("ADS");
        interstitialAdTest =ADS.GetComponent<InterstitialAdTest>();
        Score = GameObject.FindWithTag("score");
        audioSource = GetComponent<AudioSource>();
        Start_switch = false;
        Time.timeScale = 1.5f;
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        true_false = true;
         interstitialAdTest.loadInterstitialAd();
         if(interstitialAdTest.On_Off == true)
         {
             int R = Random.Range(0,7);
        if(R == 5)
        {
        ADS.GetComponent<InterstitialAdTest>().showInterstitialAd();
        }
        }
        
    }

    void FixedUpdate()
    {
      
        if(Start_switch == true)
        {
            if(Time.timeScale <= 3f)
            {
            Time.timeScale += 0.003f * Time.deltaTime;
            }
              // タッチが検出された場合
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // タッチが始まったときの位置を保存
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // タッチが離れたときの位置を保存
                endTouchPosition = touch.position;

                // スワイプの距離と方向を計算
                Vector2 swipeDirection = endTouchPosition - startTouchPosition;
                swipeDistance = Mathf.Abs(swipeDirection.x);

                // スワイプの速さを計算（距離 ÷ 時間）
                swipeSpeed = swipeDistance / (touch.deltaTime > 0 ? touch.deltaTime : 1f);

                // スワイプ速度に基づく移動速度を計算
                float adjustedSpeed = Mathf.Clamp(swipeSpeed / 100f, 0, maxSpeed);

                if (swipeDirection.x > 0)
                {
                    // 右スワイプ：オブジェクトを右に移動
                    MoveCharacter(adjustedSpeed);
                }
                else if (swipeDirection.x < 0)
                {
                    // 左スワイプ：オブジェクトを左に移動
                    MoveCharacter(-adjustedSpeed);
                }
            }
        }
        // rb.velocity = new Vector3(rb.velocity.x,0f,1f);
        if(true_false == true)
        {
               transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+ 0.1f);
        }
        if(plus == true &&  minus == false)
        {
        rb.linearVelocity = new Vector3(Mathf.Lerp(rb.linearVelocity.x, -10f, Time.deltaTime*0.5f), rb.linearVelocity.y, rb.linearVelocity.z);
        }
        else if(minus == true && plus == false)
        {
        rb.linearVelocity = new Vector3(Mathf.Lerp(rb.linearVelocity.x, 10f, Time.deltaTime*0.5f), rb.linearVelocity.y, rb.linearVelocity.z);
        }
        else
        {
            plus = false;
            minus = false;
        }
        }
      
    }

    // キャラクターをX軸方向に移動させる
    void MoveCharacter(float speed)
    {
        audioSource.Play();
        rb.linearVelocity = new Vector3(0,0,0f);
        Debug.Log(speed);
        if(speed >= 0)
        {
        plus = true;
        minus = false;
        }
        else
        {
            minus = true;
            plus = false;
        }
        // RigidbodyのX軸速度を設定して移動させる
        rb.linearVelocity = new Vector3(speed/10, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "wall")
        {
        true_false = false;
      
       Score.GetComponent<Scoreboard>().GameFinish();

        gameObject.SetActive(false);
       
        Invoke("LoadScene",0.5f);
        Instantiate(Death,transform.position, Quaternion.identity);
        }
        
    }
    void LoadScene()
    {
          SceneManager.LoadScene("SampleScene 1");
    }
}