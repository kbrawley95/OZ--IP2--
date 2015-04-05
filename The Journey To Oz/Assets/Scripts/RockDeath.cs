using UnityEngine;
using System.Collections;

public class RockDeath : MonoBehaviour {

   private BossEnemyController bossController;
   private SpawnSpiders spawnSpiders;
   private WebShot webShot;

   public Gate gate;
   public GameObject gateObj;

	// Use this for initialization
	void Start () {
        gate = gateObj.GetComponent<Gate>();
	}
	
	// Update is called once per frame
	void Update () 
    {
      
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Block2" && gate.isTriggered)
        {
            GetComponent<Animator>().SetInteger("Death", 1);
            GetComponent<BossEnemyController>().enabled = false;
            GetComponent<SpawnSpiders>().enabled = false;
            GetComponent<WebShot>().enabled = false;

        }
        else 
        {
            GetComponent<Animator>().SetInteger("Death", 0);
            GetComponent<BossEnemyController>().enabled = true;
            GetComponent<SpawnSpiders>().enabled = true;
            GetComponent<WebShot>().enabled = true;
        }
      
       
    }

    
}
