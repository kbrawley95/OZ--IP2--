using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    
    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }
}
