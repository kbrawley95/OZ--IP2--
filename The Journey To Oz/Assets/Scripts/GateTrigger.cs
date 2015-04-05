using UnityEngine;
using System.Collections;

public class GateTrigger : MonoBehaviour {

    public Gate gate;

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
            gate.isTriggered = false;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {

        if (target.gameObject.tag == "Block")
        {
            gate.isTriggered = true;
        }
           
    }

    public void Toogle(bool value)
    {
        if (value)
        {
            gate.isTriggered = true;
        }
        else
        {
            gate.isTriggered = false;
        }

    }

}
