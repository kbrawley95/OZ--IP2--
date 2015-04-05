using UnityEngine;
using System.Collections;

public class RockDeath : MonoBehaviour {

   private BossEnemyController bossController;
   private SpawnSpiders spawnSpiders;
   private WebShot webShot;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
      
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Block2")
        {
            GetComponent<Animator>().SetInteger("Death", 1);
            GetComponent<BossEnemyController>().enabled = false;
            GetComponent<SpawnSpiders>().enabled = false;
            GetComponent<WebShot>().enabled = false;

        }
        else 
        {
            GetComponent<Animator>().SetInteger("Death", 0);
           
        }
      
       
    }

    
}
