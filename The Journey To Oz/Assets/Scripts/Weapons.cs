using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

	public GameObject[] weapons; // add weapons in editor drag and drop
    public Transform attachmentPoint;
	public int currentWeapon = 0;
	public int numWeapons;
	// Use this for initialization
	void Start () {
	
		numWeapons = weapons.Length;
		changeWeapon(currentWeapon); // sets default (unarmed??)

        foreach (GameObject w in weapons)
        {
            w.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject w in weapons)
        {
            w.transform.position = attachmentPoint.position;
        }


		if(Input.GetKeyDown (KeyCode.Alpha1)){
			changeWeapon(0);
		}

			if(Input.GetKeyDown (KeyCode.Alpha2)){
				changeWeapon(1);
	}
	}

     public void changeWeapon(int num){
			currentWeapon = num;
				for(int i = 0; i < numWeapons; i++)
					if(i == num)
						weapons[i].gameObject.SetActive (true);
				else
					weapons[i].gameObject.SetActive (false);


}
}
