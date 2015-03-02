using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    public Door door;
    public bool ignoreTrigger = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if (target.gameObject.tag == "Player" || target.gameObject.tag=="Block")
            door.Open();
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if (target.gameObject.tag == "Player" || target.gameObject.tag == "Block")
            door.Close();
    }

    public void Toogle(bool value)
    {
        if (value)
        {
            door.Open();
        }
        else
        {
            door.Close();
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

        var bc2d = GetComponent<BoxCollider2D>(); //Get reference to DoorTrigger Box collider
        var bc2dPos = bc2d.transform.position; //Establish a position based on the offset and centre point of boxcollider
        var newPos = new Vector2(bc2dPos.x + bc2d.center.x, bc2dPos.y + bc2d.center.y); 
        Gizmos.DrawWireCube(newPos, new Vector2(bc2d.size.x, bc2d.size.y)); //Drawing box around door


    }
	
}
