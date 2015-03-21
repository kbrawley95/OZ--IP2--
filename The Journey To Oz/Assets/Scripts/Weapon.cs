using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    //public GameObject spiderObj;
    //EnemyController spider;
    public Movement sound;

	// Use this for initialization
	void Start () {


        //spider = spiderObj.GetComponent<EnemyController>();
        sound = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {


        if (target.gameObject.tag == "Deadly")
        {
            Destroy(target.gameObject);
            sound.PlaySwordSound();
            

            /*spider.spiderHealth -= 1;

            if (spider.spiderHealth == 0)
            {
                
            }*/

            
        }
    }
}
