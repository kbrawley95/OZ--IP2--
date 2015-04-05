using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    public Vector3[] points;
    public bool isTriggered = false;
    private int current = 0;
    public float speed = 50f;
    public float x, y, z;

    //Reference Scripts
    CollideDisable scriptManager;

    //Reference Script (Objects)
    public GameObject scriptManObj;


	// Use this for initialization
	void Start () {

        scriptManager = scriptManObj.GetComponent<CollideDisable>();
	}
    void Update()
    {
        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

    
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (!isTriggered)
        {
            transform.position = new Vector3(x, y, z);
            GetComponent<Rigidbody2D>().velocity = transform.position * speed * Time.deltaTime;
        }
        else if (isTriggered)
        {
            scriptManager.EndGame(); 
            Vector3 direction = points[current] - transform.position;
            direction = direction.normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        }
	
	}
}
