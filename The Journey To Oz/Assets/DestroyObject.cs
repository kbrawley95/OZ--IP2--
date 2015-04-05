using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    Gate gate;

    public GameObject gateObj;

	// Use this for initialization
	void Start () {
        gate = gateObj.GetComponent<Gate>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        
            if (target.gameObject.tag == "Boss" && gate.isTriggered)
            {
                Destroy(gameObject);
            }

      
       
     
    }
}
