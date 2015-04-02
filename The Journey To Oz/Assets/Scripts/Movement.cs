using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject player;
    private Weapons origin;
    public AudioClip swordSound;
    public bool isUsingController = false;

    private float xAxis;
    private float yAxis;

   
	// Use this for initialization
	void Start () 
    {
        origin = player.GetComponent<Weapons>();
        xAxis = Input.GetAxis("HorizontalRightThumb");
        yAxis = Input.GetAxis("VerticalRightThumb");
    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (origin)
        {
            //Mouse Movement
            if (origin.direction == PlayerController.DirectionState.Left &&!isUsingController || origin.direction == PlayerController.DirectionState.Right && !isUsingController)
            {
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  //subtracting the position of the sword from mouse position
                difference.Normalize(); //The sum of the vector will always be equal to 1

                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //Calculating the angle of location and converting to degrees
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
            }

            if (origin.direction == PlayerController.DirectionState.Up &&!isUsingController|| origin.direction == PlayerController.DirectionState.Down && !isUsingController)
            {
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  //subtracting the position of the sword from mouse position
                difference.Normalize(); //The sum of the vector will always be equal to 1

                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //Calculating the angle of location and converting to degrees
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
            }


            //Gamepad Movement

            else if (origin.direction == PlayerController.DirectionState.Left  &&isUsingController || origin.direction == PlayerController.DirectionState.Right && isUsingController)
            {
                if (xAxis != 0.0f || yAxis != 0.0f)
                {
                    float rot = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rot + 180);
                }
               
            }


            else if (origin.direction == PlayerController.DirectionState.Up && isUsingController || origin.direction == PlayerController.DirectionState.Down && isUsingController)
              {
                  if (xAxis != 0.0f || yAxis != 0.0f)
                  {
                      float rot = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
                      transform.rotation = Quaternion.Euler(0f, 0f, rot + 180);
                  }
              }



        }

	
	}

    public void PlaySwordSound()
    {
        if (swordSound)
        {
            AudioSource.PlayClipAtPoint(swordSound, transform.position);

        }

    }
}
