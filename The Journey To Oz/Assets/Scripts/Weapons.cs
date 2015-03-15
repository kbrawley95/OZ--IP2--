using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapons : MonoBehaviour {

    private Collectable pickItem;
    public List<GameObject> weaponsList = new List<GameObject>();
    public Transform attachmentPoint;
	public int currentWeapon = 0;
	public int numWeapons;


    //public GameObject sword;
	// Use this for initialization
	void Start () {

        numWeapons = weaponsList.Capacity;
		changeWeapon(currentWeapon); // sets default (unarmed??)
        pickItem = GetComponent<Collectable>();

        foreach (GameObject w in weaponsList)
        {
            w.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

  

        foreach (GameObject w in weaponsList)
        {
            w.transform.position = attachmentPoint.position;
        }
        
            if (Input.GetKey("1"))
            {
                changeWeapon(0);
                Debug.Log("Unarmed");
            }

            if (Input.GetKey("2"))
            {
                changeWeapon(1);
                Debug.Log("Sword");
            }
           
        
		
	    
	}

        public void changeWeapon(int num)
        {
            currentWeapon = num;
            for (int i = 0; i < numWeapons; i++)
                if (i == num)
                    weaponsList[i].gameObject.SetActive(true);
                else
                {
                    weaponsList[i].gameObject.SetActive(false);
                    
                }
                    
        }

        public void AddWeapon(GameObject pickUp)
        {
            weaponsList.Add(pickUp);
        }

        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.gameObject.tag == "PickUp")
            {
                weaponsList.Add(target.gameObject);
                target.gameObject.tag = "Untagged";

               
            }
        }
}


