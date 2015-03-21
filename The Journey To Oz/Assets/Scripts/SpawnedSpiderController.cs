using UnityEngine;
using System.Collections;

public class SpawnedSpiderController : MonoBehaviour {

    public GameObject player;
    public float followDistance;
    public float minSpeed = 50f;
    public float maxSpeed = 80f;
   // public Vector3[] points;
    public Vector3 point;
    public LayerMask layer;
    //public float spiderHealth;

    private bool IsFollowing = false;
    private int current = 0;

    private void Start()
    {
        // spiderHealth = 3;
    }

    private void Update()
    {

        if (player != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, followDistance, layer);
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
            else
                IsFollowing = false;
        }
    }

    private void FixedUpdate()
    {
        if (!IsFollowing)
        {
            float direction = -point.x;
           // direction = direction.normalized;
            GetComponent<Rigidbody2D>().velocity = new Vector3(direction, 0, 0) * Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
        }
        else if (IsFollowing)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction* Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
        }
    }
}
