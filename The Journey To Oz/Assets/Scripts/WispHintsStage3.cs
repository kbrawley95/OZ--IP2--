using UnityEngine;
using System.Collections;

public class WispHintsStage3 : MonoBehaviour {

	public bool hint = false;

	// Use this for initialization
	void Start () {



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
			GUILayout.BeginArea (new Rect((Screen.width)-1100, (Screen.height/2), 100, 100), "<color=White><size=20>Don't Die buddy.</size></color>");
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
