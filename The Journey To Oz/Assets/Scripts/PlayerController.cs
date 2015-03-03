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

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            moving.x = Input.GetAxis("Horizontal");
            anim.SetInteger("Direction", (int)DirectionState.Right);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            moving.x = Input.GetAxis("Horizontal");
            anim.SetInteger("Direction", (int)DirectionState.Left);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            moving.y = -Input.GetAxis("Vertical");
            anim.SetInteger("Direction", (int)DirectionState.Up);
        }
        else if (Input.GetAxis("Vertical") > 0.1f)
        {
            moving.y = -Input.GetAxis("Vertical");
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
