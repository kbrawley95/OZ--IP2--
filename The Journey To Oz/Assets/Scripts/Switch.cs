using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    private Animator anim;
    public DoorTrigger[] doorTriggers;
    public bool isSticky;
    private bool down = false;
   


	// Use this for initialization
	void Start () {

        anim=GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.rigidbody2D.mass == 5)
        {
            anim.SetInteger("AnimState", 1);
            down = true;
        }

        foreach (DoorTrigger dt in doorTriggers)
        {
            if (dt != null)
            {
                dt.Toogle(true);
            }

        } 
    }


    void OnTriggerExit2D(Collider2D target)
    {
        if (isSticky && down)
        {
            anim.SetInteger("AnimState", 1);
            
        }
        else if(!isSticky && down)
        {
            anim.SetInteger("AnimState", 2);

        }

       

        foreach (DoorTrigger dt in doorTriggers)
        {
            if (dt != null)
            {
                dt.Toogle(false);
            }
            
        }

       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = isSticky ? Color.red: Color.green;

        foreach (DoorTrigger dt in doorTriggers)
        {
            if (dt != null)
            {
                Gizmos.DrawLine(transform.position, dt.door.transform.position);
            }

        }
    }

   
}
