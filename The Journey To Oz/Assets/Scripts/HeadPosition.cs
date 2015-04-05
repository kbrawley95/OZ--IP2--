using UnityEngine;
using System.Collections;

public class HeadPosition : MonoBehaviour {

    public GameObject attachmentPoint;
    public GameObject spiderBody;
    Animator anim;
    Animator ownAnim;
    public Vector3[] points;
    public GameObject severedPoint;
    public float speed = 5f;
    private int current = 0;
    private bool onetime = false;

	// Use this for initialization
	void Start () {
        anim = spiderBody.GetComponent<Animator>();
        ownAnim = GetComponent<Animator>();

       
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

        if (anim.GetInteger("Death") == 0)
            transform.position = attachmentPoint.transform.position;

        if (anim.GetInteger("Death") == 1 && !onetime)
        {
            RollHead();
            onetime = true;
        }
        
               

	}

    void RollHead()
    {
           
            renderer.sortingOrder = 2;
            transform.position=Vector3.MoveTowards(attachmentPoint.transform.position, severedPoint.transform.position, speed);
            anim.SetInteger("Death", 1);
    }
}
