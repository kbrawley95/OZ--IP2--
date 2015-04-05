using UnityEngine;
using System.Collections;

public class BossSpiderDeath : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        
            if (target.gameObject.tag == "Block2")
            {
                Destroy(target.gameObject);
                anim.SetInteger("Death", 1);
               
            }
        }
       
    
}
