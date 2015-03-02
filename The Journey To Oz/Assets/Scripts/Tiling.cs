using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;			// the offset so that we don't get any weird errors
    public int offsetY = 1;	

	// these are used for checking if we need to instantiate stuff
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;

    public bool hasAUpBuddy = false;
    public bool hasADownBuddy = false;

	public bool reverseScale = false;	// used if the object is not tilable

	private float spriteWidth = 0f;		// the width of our element
    private float spriteHeight = 0f;		// the width of our element
	private Camera cam;
	private Transform myTransform;

    private List<GameObject> tiles = new List<GameObject>();

	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
        tiles.Add(gameObject);
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
        spriteHeight = sRenderer.sprite.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RemoveUnusedTiles();
		XAxis();
        YAxis();
	}

    private void RemoveUnusedTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (Vector2.Distance(new Vector2(cam.transform.position.x, cam.transform.position.y), new Vector2(tiles[i].transform.position.x, tiles[i].transform.position.y)) > 20)
            {
                tiles[i].SetActive(false);
            }
            else
            {
                tiles[i].SetActive(true);
            }
        }
    }



    void XAxis()
    {
        // does it still need buddies? If not do nothing
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
    }

    void YAxis()
    {
        // does it still need buddies? If not do nothing
        if (hasADownBuddy == false || hasAUpBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.y + spriteHeight / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.y - spriteHeight / 2) + camHorizontalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.y >= edgeVisiblePositionRight - offsetY && hasAUpBuddy == false)
            {
                MakeNewBuddyY(1);
                hasAUpBuddy = true;
            }
            else if (cam.transform.position.y <= edgeVisiblePositionLeft + offsetY && hasADownBuddy == false)
            {
                MakeNewBuddyY(-1);
                hasADownBuddy = true;
            }
        }
    }

	// a function that creates a buddy on the side required
	void MakeNewBuddy (int rightOrLeft) {
		// calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		// instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;
        tiles.Add(newBuddy.gameObject);
		// if not tilable let's reverse the x size og our object to get rid of ugly seams
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x*-1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
		}
		else {
			newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
		}
	}

    void MakeNewBuddyY(int rightOrLeft)
    {
        // calculating the new position for our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight * rightOrLeft, myTransform.position.z);
        // instantating our new body and storing him in a variable
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;
        tiles.Add(newBuddy.gameObject);
        // if not tilable let's reverse the x size og our object to get rid of ugly seams
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x, newBuddy.localScale.y * -1, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasADownBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasAUpBuddy = true;
        }
    }
}
