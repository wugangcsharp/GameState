using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	/// <summary>
	/// 游戏状态
	/// </summary>
	public static GameState gameState;
	/// <summary>
	/// 服务器列表
	/// </summary>
	private static List<ServerEntity> list=new List<ServerEntity>() ;

	/// <summary>
	/// 大区server id
	/// </summary>
	public static int parentServerId=0;
	/// <summary>
	/// 小区server id
	/// </summary>
	public static int serverId=0;
	/// <summary>
	/// 英雄名字
	/// </summary>
	public static string heroName=string.Empty;


	/// <summary>
	/// 登录窗口
	/// </summary>
	private static GameObject loginForm;

	private static GameObject heroFrom;

    private static List<ServerEntity> listParent = new List<ServerEntity>();

	void Awake(){
		loginForm=GameObject.FindGameObjectWithTag("loginForm");
		heroFrom=GameObject.Find("AnchorHero");
	}
	void Start () {
		parentServerId=1;
		gameState=GameState.ServerList;
		Change();
		 
		 
	}
	 

	public static void Change(){
		switch (gameState) {
			case GameState.ServerList:
				#region 显示大区
				DestroyButton();
				NGUITools.SetActive(loginForm,false);
				NGUITools.SetActive(heroFrom,false);
				Data data=new Data();
				list=data.GetData();
				//lambda表达式获取大区
				listParent=list.FindAll(en=>en.ParentId==0);
				//大区
				for (int i = listParent.Count-1; i >= 0; i--) {
					GameObject obj= Resources.Load("BigServer") as GameObject;
					obj=NGUITools.AddChild(GameObject.Find("AnchorLeft"),obj);
					obj.name="bigServer"+listParent[i].ServerId;
					obj.GetComponentInChildren<UILabel>().text=listParent[i].ServerName;
				}
				GameObject.Find("AnchorLeft").GetComponent<UIGrid>().repositionNow=true;	
				//显示小区
				List<ServerEntity> subList=new List<ServerEntity>();
				subList=list.FindAll(en=>en.ParentId==parentServerId);
				for (int i = 0; i < subList.Count; i++) {
					GameObject obj= Resources.Load("SmallServer") as GameObject;
					obj=NGUITools.AddChild(GameObject.Find("AnchorRight"),obj);
					obj.name="smallServer"+subList[i].ServerId;
					obj.GetComponentInChildren<UILabel>().text=subList[i].ServerName;
				}
				GameObject.Find("AnchorRight").GetComponent<UIGrid>().repositionNow=true;	
				#endregion
			break;

			case GameState.Login:
				#region 显示登录界面
				NGUITools.SetActive(loginForm,true);
				NGUITools.SetActive(heroFrom,false);
				UIButton []	games =GameObject.Find("AnchorLeft").GetComponentsInChildren<UIButton>();
				foreach (var item in games) {
					Destroy(item.gameObject);
				}
				games =GameObject.Find("AnchorRight").GetComponentsInChildren<UIButton>();
				foreach (var item in games) {
					Destroy(item.gameObject);
				}
				#endregion
			break;

			case GameState.HeroList:
				#region 选择英雄
					//关闭登录窗口
				NGUITools.SetActive(loginForm,false);
				NGUITools.SetActive(heroFrom,true);
						
				#endregion
			break;

			default:
			break;
		}
	}

	static void DestroyButton(){
		UIButton []	games =GameObject.Find("AnchorLeft").GetComponentsInChildren<UIButton>();
		foreach (var item in games) {
			Destroy(item.gameObject);
		}
		games =GameObject.Find("AnchorRight").GetComponentsInChildren<UIButton>();
		foreach (var item in games) {
			Destroy(item.gameObject);
		}
	}
	void OnGUI(){
		string path="";
		#if UNITY_STANDALONE_WIN
		path=@"Assets/Resources/data.xml";
		#endif
		
		if(Application.isEditor){
			path=Application.dataPath + @"/Resources/data.xml";
		}
		else if(Application.isWebPlayer){
				path=@"/Resources/data.xml";
		}

	}


}
public enum GameState{
	ServerList,
	Login,
	HeroList
}