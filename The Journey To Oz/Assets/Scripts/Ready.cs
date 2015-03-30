using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour {

    public GameObject partner;
    public bool partnerReady = false;


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
          partnerReady=true;
        }
    }
}
