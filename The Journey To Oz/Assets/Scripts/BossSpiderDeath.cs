using UnityEngine;
using System.Collections;

public class BossSpiderDeath : MonoBehaviour {

   public GameObject Boss;
   RockDeath death;

	// Use this for initialization
	void Start () {

        death = Boss.GetComponent<RockDeath>();
        death.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        
            if (target.gameObject.tag == "Boss")
            {

                //Destroy(gameObject);
                death.enabled = true;
            }
        }
       
    
}
