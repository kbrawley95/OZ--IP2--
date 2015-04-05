using UnityEngine;
using System.Collections;

public class BossEnemyController : MonoBehaviour
{
    public GameObject player;
    public float followDistance;
    public float minSpeed = 50f;
    public float maxSpeed = 80f;
    public Vector3[] points;
    public LayerMask layer;
    public Vector3 lastPosition;

  private Animator anim;
    //public float spiderHealth;

    private bool IsFollowing = false;
    private int current = 0;

    private void Start()
    {

        // spiderHealth = 3;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        lastPosition = transform.position;
        anim.SetInteger("Walk", 1);
        if (Vector3.Distance(points[current], transform.position) < 1)
        {
            current++;
            if (current >= points.Length)
                current = 0;
        }

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
            Vector3 direction = points[current] - transform.position;
            direction = direction.normalized;
            GetComponent<Rigidbody2D>().velocity = direction * minSpeed * Time.deltaTime;
        }
        else if (IsFollowing)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
        }
    }
}
