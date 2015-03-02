using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public AudioClip walkSound;

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
       
	}
	
	// Update is called once per frame
	private void Update ()
    {
        moving.x = moving.y = 0;

          if (Input.GetKey("right") || Input.GetKey("d") )
          {
              moving.x = 1;
              anim.SetInteger("Direction", (int)DirectionState.Right);
          }
          else if (Input.GetKey("left") || Input.GetKey("a") )
          {
              moving.x = -1;
             anim.SetInteger("Direction", (int)DirectionState.Left);
          }
          else if (Input.GetKey("up") || Input.GetKey("w") )
          {
              moving.y = 1;
              anim.SetInteger("Direction", (int)DirectionState.Up);
          }
          else if (Input.GetKey("down") || Input.GetKey("s") )
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
