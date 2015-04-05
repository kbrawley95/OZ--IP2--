using UnityEngine;
using System.Collections;

public class HeadPosition : MonoBehaviour {

    public GameObject attachmentPoint;
    public GameObject spiderBody;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = spiderBody.GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {

        if (anim.GetInteger("Death") == 0)
            transform.position = attachmentPoint.transform.position;

        else
            transform.position = transform.position;
	}
}
