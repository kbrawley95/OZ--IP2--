using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
    public GameObject player;
    public float followDistance;
    public float speed = 2f;
    public Vector3[] points;

    private bool IsFollowing = false;
    private int current = 0;

    private void Update()
    {
        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

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
            else
                IsFollowing = false;
        }
    }

    private void FixedUpdate()
    {
        if (!IsFollowing)
        {
            Vector3 direction = points[current] - transform.position;
            direction = direction.normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed * Time.deltaTime;
        }
    }
}



