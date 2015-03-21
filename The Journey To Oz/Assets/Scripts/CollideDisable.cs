﻿using UnityEngine;
using System.Collections;

public class CollideDisable : MonoBehaviour {

    CameraFollow cam;
    EnemyController controller;
    SpawnSpiders spiderSpawn;
    public GameObject obj;
    public GameObject spider;
    public GameObject background;
    private AudioSource source;

    public AudioClip battleTheme;


	// Use this for initialization
	void Start () {

        cam = obj.GetComponent<CameraFollow>();
        controller=spider.GetComponent<EnemyController>();
        controller.enabled = false;
        spiderSpawn = spider.GetComponent<SpawnSpiders>();
        spiderSpawn.enabled = false;
        source = background.GetComponent<AudioSource>();
        
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
            source.audio.Stop();
            audio.Play();

            cam.maxZoom = 1;
            cam.minZoom = 6f;

            gameObject.collider2D.enabled = false;
            //cam.enabled = false;
        }
    }

   /* public void PlayBattleTheme()
    {
        if (battleTheme)
        {
            AudioSource.PlayClipAtPoint(battleTheme, transform.position, .5f);

        }
    }*/
}
