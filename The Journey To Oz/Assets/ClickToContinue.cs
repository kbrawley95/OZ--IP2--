using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {

    private bool gamePaused = false;
    //private string scene;
    private bool again = false;


	// Use this for initialization
	void Start () {
        //scene = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {

        gamePaused = !gamePaused;

        if (Input.GetKey("p")&& !again)
        {
            gamePaused = true;
            again = true;
        }

        if (Input.GetKey("p") && again)
        {
            gamePaused = false;
        }

        if (gamePaused)
        {
            Time.timeScale = 0;
        }
            
        else
        {
            Time.timeScale = 1;
        }
           
	}
}
