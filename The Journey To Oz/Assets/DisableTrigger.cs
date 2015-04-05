using UnityEngine;
using System.Collections;

public class DisableTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
