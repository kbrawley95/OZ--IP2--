﻿using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    //public GameObject cam;
    public int speed = 1;
    public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // cam.transform.Translate(Vector3.up * Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

	}

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(20);
        Application.LoadLevel(scene);
    }
}
