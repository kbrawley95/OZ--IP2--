using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed = 2f;
    public Vector3 startingPositionX;
    public Vector3 endingPositionX;
   

    void Start()
    {
       
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(transform.localScale.x, 0) * speed;

        if (gameObject.transform.localScale.x == endingPositionX.x)
        {
            this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1 : 1, 1, 1);
        }
    }



   /* void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
       
    } */
}



