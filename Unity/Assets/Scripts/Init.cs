using System;
using System.Threading;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using ETModel;

public class Init : MonoBehaviour
{
    public InputField nickname;
    public InputField password;
    public Button login;
    public Button enterMap;

    GameObject uiLogin;
    GameObject uiLobby;

	private readonly OneThreadSynchronizationContext contex = new OneThreadSynchronizationContext();

	private async void Start()
	{
		try
		{
			if (Application.unityVersion != "2017.1.0p5")
			{
				Log.Warning($"当前版本:{Application.unityVersion}, 最好使用运行指南推荐版本!");
			}

			SynchronizationContext.SetSynchronizationContext(this.contex);

			DontDestroyOnLoad(gameObject);
			Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);

			Game.Scene.AddComponent<GlobalConfigComponent>();
			Game.Scene.AddComponent<NetOuterComponent>();
			Game.Scene.AddComponent<ResourcesComponent>();
			Game.Scene.AddComponent<PlayerComponent>();
			Game.Scene.AddComponent<UnitComponent>();
			Game.Scene.AddComponent<ClientFrameComponent>();
			//Game.Scene.AddComponent<UIComponent>();

			// 下载ab包
			await BundleHelper.DownloadBundle();

			// 加载配置
			Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("config.unity3d");
			Game.Scene.AddComponent<ConfigComponent>();
			Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");
			Game.Scene.AddComponent<OpcodeTypeComponent>();
			Game.Scene.AddComponent<MessageDispatherComponent>();


            uiLogin = GameObject.Find("LoginCanvas");
            uiLobby = GameObject.Find("LobbyCanvas");
            uiLobby.SetActive(false);

            login.GetComponent<Button>().onClick.Add(OnLogin);
            enterMap.GetComponent<Button>().onClick.Add(EnterMap);

            UnitConfig unitConfig = (UnitConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(UnitConfig), 1001);
            Log.Debug($"config {JsonHelper.ToJson(unitConfig)}");

            Game.EventSystem.Run(EventIdType.InitSceneStart);
		}
		catch (Exception e)
		{
			Log.Error(e.ToString());
		}
	}

    public async void OnLogin()
    {
        SessionWrap sessionWrap = null;
        try
        {
            IPEndPoint connetEndPoint = NetworkHelper.ToIPEndPoint(GlobalConfigComponent.Instance.GlobalProto.Address);


            Session session = Game.Scene.GetComponent<NetOuterComponent>().Create(connetEndPoint);
            sessionWrap = new SessionWrap(session);
            R2C_Login r2CLogin = (R2C_Login)await sessionWrap.Call(new C2R_Login() { Account = nickname.text, Password = "111111" });
            sessionWrap.Dispose();

            connetEndPoint = NetworkHelper.ToIPEndPoint(r2CLogin.Address);
            Session gateSession = Game.Scene.GetComponent<NetOuterComponent>().Create(connetEndPoint);
            Game.Scene.AddComponent<SessionWrapComponent>().Session = new SessionWrap(gateSession);
            Game.Scene.AddComponent<SessionComponent>().Session = gateSession;
            //G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await SessionWrapComponent.Instance.Session.Call(new C2G_LoginGate() { Key = r2CLogin.Key });


            G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await Game.Scene.GetComponent<SessionWrapComponent>().Session.Call(new C2G_LoginGate() { Key = r2CLogin.Key });

            Log.Info("登陆gate成功!");

            // 创建Player
            Player player = ETModel.ComponentFactory.CreateWithId<Player>(g2CLoginGate.PlayerId);
            PlayerComponent playerComponent = ETModel.Game.Scene.GetComponent<PlayerComponent>();
            playerComponent.MyPlayer = player;

            uiLogin.SetActive(false);
            uiLobby.SetActive(true);
        }
        catch (Exception e)
        {
            Log.Error(e.ToString());
        }

    }

    private async void EnterMap()
    {
        try
        {
            G2C_EnterMap g2CEnterMap = (G2C_EnterMap)await SessionComponent.Instance.Session.Call(new C2G_EnterMap());


            uiLobby.SetActive(false);
            Log.Info("EnterMap...");
        }
        catch (Exception e)
        {
            Log.Error(e.ToString());
        }
    }

	private void Update()
	{
		this.contex.Update();
		Game.Hotfix.Update?.Invoke();
		Game.EventSystem.Update();
	}

	private void LateUpdate()
	{
		Game.Hotfix.LateUpdate?.Invoke();
		Game.EventSystem.LateUpdate();
	}

	private void OnApplicationQuit()
	{
		Game.Hotfix.OnApplicationQuit?.Invoke();
		Game.Close();
	}
}
