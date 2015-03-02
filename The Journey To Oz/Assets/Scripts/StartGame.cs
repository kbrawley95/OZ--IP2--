using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public string scene;
    private bool loadScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !loadScene)
        {
            LoadScene();
        }

	}

    void LoadScene()
    {
        loadScene = true;
        Application.LoadLevel(scene);
    }
}
