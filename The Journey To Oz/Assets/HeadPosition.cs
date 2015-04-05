using UnityEngine;
using System.Collections;

public class HeadPosition : MonoBehaviour {

    public GameObject attachmentPoint;

	// Use this for initialization
	void Start () {
	    
       
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = attachmentPoint.transform.position;
	}
}
