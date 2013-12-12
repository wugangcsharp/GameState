using UnityEngine;
using System.Collections;

public class HeroControllers : MonoBehaviour {
	UISprite sprite;
	GameObject [] heros;

	// Use this for initialization
	void Start () {
		sprite=this.GetComponent<UISprite>();
		sprite.color=new Color(128,128,128);
		heros=GameObject.FindGameObjectsWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		foreach (GameObject item in heros) {
			item.GetComponent<UISprite>().color=new Color(128,128,128);
//			item.GetComponent<TweenColor>().to=new Color(128,128,128);
//			item.GetComponent<TweenColor>().from=new Color(128,128,128);
			item.transform.localScale=new Vector3(0.003333333f,0.003333333f,0.003333333f);
		}
		sprite.color=new Color(153,255,51);
		this.transform.localScale=new Vector3(0.003333333f*1.5f,0.003333333f*1.5f,0.003333333f*1.5f);
	}
}
