using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

    public bool isVisible = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isVisible)
        {
           renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
	}
}
