using UnityEngine;
using System.Collections;

public class GateSwitch : MonoBehaviour {

	// Use this for initialization
    private Animator anim;
    public GateTrigger[] gateTriggers;
    public bool isSticky;
    private bool down = false;



    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag=="Block")
        {
            anim.SetInteger("AnimState", 1);
            down = true;

            foreach (GateTrigger gt in gateTriggers)
            {
                if (gt != null)
                {
                    gt.Toogle(false);
                }

            }

        }

      
    }


    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Block")
        {
            if (isSticky && down)
            {
                anim.SetInteger("AnimState", 1);

            }
            else if (!isSticky && down)
            {
                anim.SetInteger("AnimState", 2);

            }



            foreach (GateTrigger gt in gateTriggers)
            {
                if (gt != null)
                {
                    gt.Toogle(true);
                }

            }
        }
      


    }

    void OnDrawGizmos()
    {
        Gizmos.color = isSticky ? Color.red : Color.green;

        foreach (GateTrigger gt in gateTriggers)
        {
            if (gt != null)
            {
                Gizmos.DrawLine(transform.position, gt.gate.transform.position);
            }

        }
    }

}
