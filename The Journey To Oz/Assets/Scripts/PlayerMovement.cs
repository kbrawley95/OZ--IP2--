using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float sprintSpeed = 15f;
    public Vector2 maxVel = new Vector2(3, 3);
    public bool isSprinting = false;

    public PlayerController controller;

	// Use this for initialization
	private void Start () 
    {
        controller = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	private void Update () 
    {

        var forceX = 0f;
        var forceY = 0f;

        var absVelX = Mathf.Abs(rigidbody2D.velocity.x);
        var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

        if (controller.moving.x != 0 && !isSprinting)
        {
            if (absVelX < maxVel.x)
            {
                forceX = controller.moving.x * speed;
            }
        }
        if (controller.moving.y != 0 && !isSprinting)
        {
            if (absVelY < maxVel.y)
            {
                forceY = controller.moving.y * speed;
            }
        }

        if (controller.moving.x != 0 && isSprinting)
        {
            if (absVelX < maxVel.x)
            {
                forceX = controller.moving.x * sprintSpeed;
            }
        }
        if (controller.moving.y != 0 && isSprinting)
        {
            if (absVelY < maxVel.y)
            {
                forceY = controller.moving.y * sprintSpeed;
            }
        }

        if (Input.GetKey("left shift"))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }


        rigidbody2D.AddForce(new Vector2(forceX, forceY));
	}
}
