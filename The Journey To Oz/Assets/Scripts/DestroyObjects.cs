using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Freeze")
        {
            Destroy(target.gameObject);
        }
    }
}
