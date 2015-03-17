using UnityEngine;
using System.Collections;

public class CollideDisable : MonoBehaviour {

    public Camera camera;
	// Use this for initialization
	void Start () {

        camera.GetComponent<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
      

	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
            camera.enabled = false;
    }
}

