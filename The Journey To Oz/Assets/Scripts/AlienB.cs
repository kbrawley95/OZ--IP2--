using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {
    private Animator anim;
    public bool readyToAttack;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (readyToAttack)
            {
                var death = target.GetComponent<Death>() as Death;
                death.OnDeath();

            }
            else
            {
                anim.SetInteger("AnimState", 1);
            }
        }
   
    }

    void OnTriggerExit2D(Collider2D target)
    {
        readyToAttack = false;
        anim.SetInteger("AnimState", 0);
    }

    void Attack()
    {
        readyToAttack = true;
    }
}
