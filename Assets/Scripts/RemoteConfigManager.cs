using UnityEngine;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using System.Threading.Tasks;
public class RemoteConfigManager : MonoBehaviour
{
    // シングルトンのインスタンス
    public static RemoteConfigManager Instance { get; private set; }

    // userAttributesとappAttributesの構造体を定義
    private struct userAttributes { }
    private struct appAttributes { }
    public string key_ad_banner;
    public string key_ad_interstitial;

    async void Awake()
    {
        // シングルトンの設定
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Unity Servicesの初期化
        await UnityServices.InitializeAsync();

        // 匿名サインイン
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        // Remote Configの設定を取得
        await FetchRemoteConfig();
    }

    private async Task FetchRemoteConfig()
    {
        // 設定を取得
        await RemoteConfigService.Instance.FetchConfigsAsync(new userAttributes(), new appAttributes());

        // 取得した設定値を使用
        key_ad_banner = RemoteConfigService.Instance.appConfig.GetString("key_ad_banner", "ca-app-pub-3940256099942544/6300978111");
        key_ad_interstitial = RemoteConfigService.Instance.appConfig.GetString("key_ad_interstitial", "ca-app-pub-3940256099942544/1033173712");
    }
}
