using UnityEngine;
using System.Collections;

public class BigServerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		//GameManager.parentServerId
		string parentServerId=this.gameObject.name.Replace("bigServer","");
		int.TryParse(parentServerId,out GameManager.parentServerId);
		GameManager.Change();
	}
}
