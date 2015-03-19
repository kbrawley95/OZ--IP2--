using UnityEngine;
using System.Collections;

public class CollideDisable : MonoBehaviour {

    CameraFollow cam;
    EnemyController controller;
    SpawnSpiders spiderSpawn;
    public GameObject obj;
    public GameObject spider;


	// Use this for initialization
	void Start () {

        cam = obj.GetComponent<CameraFollow>();
        controller=spider.GetComponent<EnemyController>();
        controller.enabled = false;
        spiderSpawn = spider.GetComponent<SpawnSpiders>();
        spiderSpawn.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
      

	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            spiderSpawn.enabled = true;
            controller.enabled = true;

            cam.maxZoom = 1;
            cam.minZoom = 6f;
            //cam.enabled = false;
        }
    }
}

