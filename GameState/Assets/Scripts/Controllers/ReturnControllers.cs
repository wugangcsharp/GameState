using UnityEngine;
using System.Collections;

public class ReturnControllers : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		GameManager.gameState=GameState.ServerList;
		GameManager.Change();
	}
}
