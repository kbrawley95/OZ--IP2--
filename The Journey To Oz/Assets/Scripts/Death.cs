using UnityEngine;
using System.Collections;

public class Death: MonoBehaviour {

    //public BodyPart bodyPart;
    //public int totalParts=5;

    public string scene;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Method that determines whether the object colliding with the player is an ememy
    /// </summary>
    /// <param name="target"></param>
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag=="Deadly")    
        {
            OnDeath();
            
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnDeath();
        }
    }

    /// <summary>
    /// Method that removes player from game scene
    /// </summary>
    public void OnDeath()
    {
        Destroy(gameObject);
        Application.LoadLevel(scene);

        /*var t = transform;

        for (int i = 0; i < totalParts; i++)
        {
            t.TransformPoint(0,-100, 0);
            BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
            clone.rigidbody2D.AddForce(Vector3.right * Random.Range(-50, 50));
            clone.rigidbody2D.AddForce(Vector3.up * Random.Range(100, 400));
        }*/
    }

    
}
