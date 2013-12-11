using UnityEngine;
using System.Collections;

public class SmallServerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		//login
		GameManager.gameState=GameState.Login;
		GameManager.Change();
	}
}
