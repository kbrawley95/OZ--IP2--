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
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Mathf.Abs(Input.GetAxis("HorizontalRightThumb")) > 0.2 || Mathf.Abs(Input.GetAxis("VerticalRightThumb")) > 0.2)
        {
            isUsingController = true;
        }
        else
            isUsingController = false;

        if (origin)
        {
            if (!isUsingController)
            {
                //Mouse movement
                Vector2 mousePosition = Input.mousePosition; //Get Mouse Position

                //Center of the screen is 0, 0
                mousePosition.x -= Screen.width / 2;
                mousePosition.y -= Screen.height / 2;

                //Normalize mouse position
                mousePosition = mousePosition.normalized;

                //Claculate angle to rotate
                float angle = Mathf.Atan(mousePosition.y / mousePosition.x);
                
                //Convert to degrees
                angle = angle * 180 / Mathf.PI;

                //When x is negative flip the sword
                if (mousePosition.x > 0)
                {
                    //Sword is rotated 90 degrees so to make it look nice offset it by 90
                    angle -= 90;
                }
                else if (mousePosition.x < 0)
                {
                    angle += 90;
                }

                //Rotate sword
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            else
            {
                

                xAxis = Input.GetAxis("HorizontalRightThumb");
                yAxis = -Input.GetAxis("VerticalRightThumb");

                //Gamepad Movement
                if (xAxis != 0 && yAxis != 0)
                {
                    //Get Joystick axies
                    Vector2 joystick = new Vector2(xAxis, yAxis);

                    //Claculate angle to rotate
                    float angle = Mathf.Atan(joystick.y / joystick.x);

                    //Convert to degrees
                    angle = angle * 180 / Mathf.PI;

                    //When x is negative flip the sword
                    if (joystick.x > 0)
                    {
                        //Sword is rotated 90 degrees so to make it look nice offset it by 90
                        angle -= 90;
                    }
                    else if (joystick.x < 0)
                    {
                        angle += 90;
                    }

                    //Rotate sword
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
