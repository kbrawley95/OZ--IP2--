using UnityEngine;
using System.Collections;

public class WispHintsStage2 : MonoBehaviour {

	public bool hint = false;




	public void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("HintButton"))
		{
			hint =  !hint;
			toggleHint();

		}


	}
	void OnGUI()
	{
		if(hint)
		{
			GUILayout.BeginArea (new Rect((Screen.width)-1100, (Screen.height/2), 100, 100), "<color=White><size=20>Why don't you try to push these rocks?</size></color>");
			//GUILayout.Label("Wisp Hints.");

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
