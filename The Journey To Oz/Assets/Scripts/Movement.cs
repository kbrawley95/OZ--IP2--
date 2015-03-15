using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject player;
    private Weapons origin;
	// Use this for initialization
	void Start () 
    {
        origin = player.GetComponent<Weapons>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (origin)
        {
            if (transform.position == origin.attachmentPoint.position)
            {
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  //subtracting the position of the sword from mouse position
                difference.Normalize(); //The sum of the vector will always be equal to 1

                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //Calculating the angle of location and converting to degrees
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
            }
        }
    
        
       
	
	}
}
