using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    public GameObject spiderBoss;

    public Vector3[] points;
    private int current = 0;
    public float speed = 40;

    public float x, y, z;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

            points[current] = new Vector3(x, y, z);
            Vector3 direction = points[current] - transform.position;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
	}
}
