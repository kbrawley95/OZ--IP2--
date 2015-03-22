using UnityEngine;
using System.Collections;

public class FreezePlayer : MonoBehaviour {

    public PlayerMovement player;
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Freeze")
        {
            player.isFrozen = true;
            StartCoroutine(Freeze());

        }
        else
        {
            gameObject.collider2D.isTrigger = false;
        }
    }

    private IEnumerator Freeze()
    {
        Debug.Log("Working");
        //Backup and clear velocities
        Vector2 originalVelocity = rigidbody2D.velocity;
        rigidbody2D.velocity=new Vector2(0,0);
        yield return new WaitForSeconds(4);
        Debug.Log("Working");
        rigidbody2D.velocity = originalVelocity;
        player.isFrozen = false;
       
    
    }
}
