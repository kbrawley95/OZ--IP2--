using UnityEngine;
using System.Collections;

public class ContinousPlay : MonoBehaviour {

    public AudioClip forestSong;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        AudioSource.PlayClipAtPoint(forestSong, transform.position);

	}
}
