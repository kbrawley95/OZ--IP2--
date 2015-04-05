using UnityEngine;
using System.Collections;

public class RockManagement : MonoBehaviour {

    Invisible invisible;
    public GameObject rock;
    public GameObject rockKiller;
	// Use this for initialization
	void Start () {
        invisible = rock.GetComponent<Invisible>();
	}
	
	// Update is called once per frame
	void Update () {

        if (rock)
        {
            Destroy(rockKiller);
        }

        invisible.isVisible = true;
	}
}
