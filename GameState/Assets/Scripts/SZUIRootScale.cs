using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent(typeof(UIRoot))]
public class SZUIRootScale : MonoBehaviour
{
	public int aspectRatioHeight;
	public int aspectRatioWidth;
	private UIRoot root;
	
	void Awake ()
	{
		root = NGUITools.FindInParents<UIRoot> (this.gameObject);
		float defaultAspectRatio = aspectRatioWidth * 1f / aspectRatioHeight;
		float currentAspectRatio = Screen.width * 1f / Screen.height;
		if (defaultAspectRatio > currentAspectRatio) {
			int horizontalManualHeight = Mathf.FloorToInt (aspectRatioWidth / currentAspectRatio);
			root.manualHeight = horizontalManualHeight/10*10;
		} else {
			root.manualHeight = aspectRatioHeight;
		}
	}
	
	void Update ()
	{

	}
}
