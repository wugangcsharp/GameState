using UnityEngine;
using System.Collections;

public class LoginControllers : MonoBehaviour {


	public UIInput username;
	public UIInput password;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		//验证用户账号
		if(ValidUser(username.value,password.value,GameManager.parentServerId,GameManager.serverId)){
			GameManager.gameState=GameState.HeroList;
			GameManager.Change();
		}
	}

	/// <summary>
	/// 验证用户信息
	/// </summary>
	/// <returns><c>true</c>, if user was valided, <c>false</c> otherwise.</returns>
	/// <param name="username">Username.</param>
	/// <param name="password">Password.</param>
	/// <param name="parentServerId">Parent server identifier.</param>
	/// <param name="serverId">Server identifier.</param>
	bool ValidUser(string  username,string password,int parentServerId, int serverId){
		return true;
	}
}
