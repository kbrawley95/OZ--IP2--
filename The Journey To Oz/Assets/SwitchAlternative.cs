using UnityEngine;
using System.Collections;

public class SwitchAlternative : MonoBehaviour {

    public bool isPressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Block")
        {
            isPressed = true;

        }
           
    }
  

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Block")
            isPressed = false;
    }
    
}
