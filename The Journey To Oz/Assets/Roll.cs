using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    RockDeath death;
    public GameObject spiderBoss;

    public Vector3[] points;
    private int current = 0;
    public float speed = 40;

	// Use this for initialization
	void Start () {

        death = spiderBoss.GetComponent<RockDeath>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

        if (death.enabled)
        {
            Vector3 direction = points[current] - transform.position;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        }
	}
}
