using UnityEngine;
using System.Collections;

public class Death: MonoBehaviour {

    public string scene;
    public AudioClip deathSound;


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
        if (target.gameObject.tag=="Deadly"||target.gameObject.tag=="Boss")    
        {
            PlayDeathSound();
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

     
    }

    public void PlayDeathSound()
    {
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
        
    }

    
}
