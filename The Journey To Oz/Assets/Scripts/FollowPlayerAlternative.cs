using UnityEngine;
using System.Collections;

public class FollowPlayerAlternative : MonoBehaviour {

    public GameObject player;
    public float speed = 1f;
    public float followDistance;
    public bool IsFollowing = false;
    

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, followDistance);
            Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * followDistance, Color.green, 1);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    IsFollowing = true;
                }
                else
                {
                    IsFollowing = false;
                }

            }




        }
    }

    void FixUpdate()
    {
        if (IsFollowing)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        }
    }
}
