using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float speed=10f;
    public Vector2 maxVel=new Vector2(3,5);
    public bool onGround = true;
    public float jetSpeed = 15f;

    public float airSpeedMultiplier = .3f;

    private PlayerController controller;	// Use this for initialization
    private Animator anim;
	void Start () {

        controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
    void Update()
    {

        var forceX = 0f;
        var forceY = 0f;

        var absVelX = Mathf.Abs(rigidbody2D.velocity.x);
        var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

        if (absVelY < .2f)
        {
            onGround = true;
        }
        else
            onGround = false;

        if(controller.moving.x!=0)
        {
            if(absVelX <maxVel.x)
            {
             
                forceX = onGround ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);

                transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
            }
            anim.SetInteger("AnimState", 1);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }
        

        if (controller.moving.y>0)
        {
            if (absVelY < maxVel.y)
                forceY= jetSpeed * controller.moving.y;

            anim.SetInteger("AnimState", 2);
        }
        else if (absVelX > 0)
        {
            anim.SetInteger("AnimState", 3);
        }

      


        rigidbody2D.AddForce(new Vector2(forceX, forceY));


        
    }    
}
