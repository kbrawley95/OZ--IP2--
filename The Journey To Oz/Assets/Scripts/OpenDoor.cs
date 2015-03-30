using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public SwitchAlternative switch1;
    public SwitchAlternative switch2;
    public Door door;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (switch1.isPressed && switch2.isPressed)
        {

            door.Open();
        }
        else door.Close();
	
	}
}
