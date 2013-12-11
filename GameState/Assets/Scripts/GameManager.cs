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
	private static List<ServerEntity> list ;

	/// <summary>
	/// 大区server id
	/// </summary>
	public static int parentServerId=0;

	private static GameObject returnButton;

	void Awake(){
		returnButton=GameObject.Find("Retrun");
	}
	void Start () {
		parentServerId=1;
		gameState=GameState.ServerList;
		Change();

		 
	}
	 

	public static void Change(){
		switch (gameState) {
			case GameState.ServerList:
				DestroyButton();
				NGUITools.SetActive(returnButton,false);
				Data data=new Data();
				list=data.GetData();
				//lambda表达式获取大区
				List<ServerEntity> listParent=list.FindAll(en=>en.ParentId==0);
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
			break;

			case GameState.Login:
				NGUITools.SetActive(returnButton,true);
				UIButton []	games =GameObject.Find("AnchorLeft").GetComponentsInChildren<UIButton>();
				foreach (var item in games) {
					Destroy(item.gameObject);
				}
				games =GameObject.Find("AnchorRight").GetComponentsInChildren<UIButton>();
				foreach (var item in games) {
					Destroy(item.gameObject);
				}
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

}
public enum GameState{
	ServerList,
	HeroList,
	Login
}