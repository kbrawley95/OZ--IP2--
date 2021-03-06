﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapons : MonoBehaviour
{

    private Collectable pickItem;
    public List<WeaponPositioner> weaponsList = new List<WeaponPositioner>();
    private Vector3 lastPosition=Vector3.zero;
    [System.NonSerialized]
    public PlayerController.DirectionState direction = PlayerController.DirectionState.Right;
	public int currentWeapon = 0;
	public int numWeapons;
    public bool isSetActive = false;
   Movement script;
    public GameObject sword;


    //public GameObject sword;
	// Use this for initialization
	void Start () {

        numWeapons = weaponsList.Capacity;
		changeWeapon(currentWeapon); // sets default (unarmed??)
        pickItem = GetComponent<Collectable>();

        foreach (WeaponPositioner w in weaponsList)
        {
            if (isSetActive)
                w.weapon.SetActive(true);
            else
                w.weapon.SetActive(false);
        }

        script = sword.GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (WeaponPositioner w in weaponsList)
        {
            lastPosition = w.weapon.transform.position;

            //Keyboard & Gamepad
           if (Input.GetKey("w")||(Input.GetAxis("Vertical") == -1f ))
           {
               direction = PlayerController.DirectionState.Up;
           }

           else if (Input.GetKey("s") || (Input.GetAxis("Vertical") == 1f))
           {
               direction = PlayerController.DirectionState.Down;
           }

           else if (Input.GetKey("d") || (Input.GetAxis("Horizontal") == 1f))
           {
               direction = PlayerController.DirectionState.Right;
           }


           else if (Input.GetKey("a") || (Input.GetAxis("Horizontal") == -1f))
           {
               direction = PlayerController.DirectionState.Left;
           }

           else
           {
               w.weapon.transform.rotation.Set(0, 0, 0, 0);
               w.weapon.transform.position = lastPosition;

           }

           if (direction == PlayerController.DirectionState.Up)
           {
               w.weapon.transform.position = w.top.position;
               w.weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
               //w.weapon.renderer.sortingLayerID = 1;
           }
           else if (direction == PlayerController.DirectionState.Down)
           {
               w.weapon.transform.position = w.bottom.position;
               w.weapon.GetComponent<SpriteRenderer>().sortingOrder = 2;
               //w.weapon.renderer.sortingLayerID = 1;
           }
           else if (direction == PlayerController.DirectionState.Left)
           {
               w.weapon.transform.position = w.left.position;
               w.weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
               //w.weapon.renderer.sortingLayerID = 1;
           }
           else if (direction == PlayerController.DirectionState.Right)
           {
               w.weapon.transform.position = w.right.position;
               //w.weapon.renderer.sortingLayerID = 1;
               w.weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
           }
              
        }



        /* 
         * 
         *  if (Input.GetKey("1")||Input.GetButton("ChangeWeaponPrevious"))
         {
             changeWeapon(0);
             Debug.Log("Unarmed");
         }
         * if (Input.GetKey("2") || Input.GetButton("ChangeWeaponNext"))
         {
             changeWeapon(1);
             Debug.Log("Sword");
         }*/




    }

        public void changeWeapon(int num)
        {
            currentWeapon = num;
            for (int i = 0; i < weaponsList.Count; i++)
            { 
                if (i == num)
                    weaponsList[i].weapon.gameObject.SetActive(true);
                else
                {
                    Debug.Log(currentWeapon);
                    weaponsList[i].weapon.gameObject.SetActive(false);
                }
            }
        }

        public void AddWeapon(GameObject pickUp)
        {
            weaponsList.Add(new WeaponPositioner(pickUp));
        }

        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.gameObject.tag == "PickUp")
            {
                //weaponsList.Add(new WeaponPositioner(target.gameObject));
                Destroy(target.gameObject);
                foreach (WeaponPositioner w in weaponsList)
                {
                        w.weapon.SetActive(true);
                        
                }
                script.gameObject.SetActive(true);
                target.gameObject.tag = "Untagged";

              
            }
        }
}

[System.Serializable]
public class WeaponPositioner
{
    public GameObject weapon;
    public Transform top;
    public Transform right;
    public Transform left;
    public Transform bottom;

    public WeaponPositioner(GameObject weapon)
    {
        this.weapon = weapon;
    }
}