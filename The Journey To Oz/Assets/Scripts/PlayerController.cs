using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public AudioClip walkSound;
    public DirectionState StartingDirection;

    public enum DirectionState
    {
        Right = 3,
        Left = 2,
        Up = 0,
        Down = 1
    }

    public Vector2 moving = new Vector2();

	// Use this for initialization
	private void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Direction", (int)StartingDirection);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        moving.x = moving.y = 0;


        //Gamepad Controller
        if (Input.GetAxis("Horizontal") ==1f)
        {
            moving.x = Input.GetAxis("Horizontal");
            anim.SetInteger("Direction", (int)DirectionState.Right);
        }
        else if (Input.GetAxis("Horizontal") == -1f)
        {
            moving.x = Input.GetAxis("Horizontal");
            anim.SetInteger("Direction", (int)DirectionState.Left);
        }
        else if (Input.GetAxis("Vertical") == 1f)
        {
            moving.y = -Input.GetAxis("Vertical");
            anim.SetInteger("Direction", (int)DirectionState.Down);
        }
        else if (Input.GetAxis("Vertical") ==-1f)
        {
            moving.y =- Input.GetAxis("Vertical");
            anim.SetInteger("Direction", (int)DirectionState.Up);
        }

        if (moving != Vector2.zero)
        {
            anim.SetInteger("Speed", 1);
        }
        else
        {
            anim.SetInteger("Speed", 0);
        }

        //Keyboard Controller
        if (Input.GetKey("a"))
        {
            moving.x = -1;
            anim.SetInteger("Direction", (int)DirectionState.Left);
        }

        else if (Input.GetKey("d"))
        {
            moving.x = 1;
            anim.SetInteger("Direction", (int)DirectionState.Right);
        }

        else if (Input.GetKey("w"))
        {
            moving.y = 1;
            anim.SetInteger("Direction", (int)DirectionState.Up);
        }

        else if (Input.GetKey("s"))
        {
            moving.y = -1;
            anim.SetInteger("Direction", (int)DirectionState.Down);
        }

        if (moving != Vector2.zero)
        {
            anim.SetInteger("Speed", 1);
        }
        else
        {
            anim.SetInteger("Speed", 0);
        }
	}

    void PlayWalkSound()
    {
        if (walkSound)
        {
            AudioSource.PlayClipAtPoint(walkSound, transform.position);
            
        }
           
    }
}
