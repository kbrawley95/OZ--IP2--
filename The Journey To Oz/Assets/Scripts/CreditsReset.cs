using UnityEngine;
using System.Collections;

public class CreditsReset : MonoBehaviour {

    public string scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(WaitFor());

	}

    private IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(130);
        Application.LoadLevel(scene);
    }
}
