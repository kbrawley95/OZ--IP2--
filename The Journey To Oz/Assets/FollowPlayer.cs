using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public float speed = 1f;
    

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = (player.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;

        if(transform.position==player.transform.position)
        {
            speed = 0;
        }

	}
}
