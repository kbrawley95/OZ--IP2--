using UnityEngine;
using System.Collections;

public class WispHints : MonoBehaviour {

	public bool hint = false;
	public bool intro = false;
	// Use this for initialization
	void Start () {

		intro = !intro;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("HintButton"))
		{
			hint =  !hint;
			toggleHint();
			intro = false;
		}


	}
	void OnGUI()
	{
		if(hint)
		{
			GUILayout.BeginArea (new Rect((Screen.width)-1100, (Screen.height/2), 100, 100), "<color=White><size=20>Spiders! Why'd it have to be spiders?</size></color>");
			//GUILayout.Label("Wisp Hints.");
			
			GUILayout.EndArea();
			
			
		}
		if(intro)
		{
			GUILayout.BeginArea (new Rect((Screen.width)-1100, (Screen.height/2), 100, 100), "<color=White><size=20>I may as well follow you around and tell you obvious things.</size></color>");
			//GUILayout.Label("Wisps Intro");
			
			GUILayout.EndArea();
			
			
		}
	}  
	bool toggleHint()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
}


}
