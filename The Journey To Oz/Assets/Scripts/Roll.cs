using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    public GameObject spiderBoss;

    public Vector3 point;
    private int current = 0;
    public float speed = 40;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

           Vector3 direction= transform.position+point;
            GetComponent<Rigidbody2D>().velocity =  direction * Time.deltaTime;

            if (transform.position == point)
            {
                transform.position = point;
            }
	}
}
