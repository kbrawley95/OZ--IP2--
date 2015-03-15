using UnityEngine;
using System.Collections;

public class DisableCollider : MonoBehaviour {

    PolygonCollider2D collider;
    private int rockCounter;

    public int RockCounter
    {
        get { return rockCounter; }
        set { rockCounter = value; }
    }

	// Use this for initialization
	void Start () {
        rockCounter = 0;
        collider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (collider != null)
        {
            if (rockCounter == 3)
                collider.enabled = false;
        }
     
	}
}
