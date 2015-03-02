using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour {

    public enum DoorState 
    { 
        IDLE = 0,
        OPENING = 1,
        OPEN = 2,
        CLOSING = 3,
    }

   
    public float closeDelay = 0.5f;

    private int state = (int)DoorState.IDLE;
    private Animator anim;

    public string scene;

    Switch switchObject;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        switchObject = GetComponent<Switch>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnOpenStart()
    {
        state = (int)DoorState.OPENING;
    }

     void OnOpenEnd()
    {
        state = (int)DoorState.OPEN;
    }

      void OnCloseStart()
    {
        state = (int)DoorState.CLOSING;
    }

     void OnCloseEnd()
    {
        state = (int)DoorState.IDLE;
    }

     void DisableCollider2D()
     {
         collider2D.enabled = false;
     }

     void EnableCollider2D()
     {
         collider2D.enabled = true;
     }

     public void Open()
     {
         anim.SetInteger("AnimState", 1);

     }

     public void Close()
     {
         StartCoroutine(CloseNow());
     }

     private IEnumerator CloseNow()
     {
         yield return new WaitForSeconds(closeDelay);
         anim.SetInteger("AnimState", 2);
     }

     void OnTriggerEnter2D(Collider2D target)
     {
         if (target.gameObject.tag == "Player")
         {
             Destroy(target.gameObject);
             Application.LoadLevel(scene);
         }
     }

   

}

