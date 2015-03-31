using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebShot : MonoBehaviour
{

    public GameObject webShotPrefab;
    public float maxSpeed, minSpeed;
    public Vector3 offSet = Vector3.zero;
    public float startingDelay = 1.0f;
    public float delayMin, delayMax = 2.0f;
    public int counter, limit;
    PlayerMovement player;

    private List<GameObject> webShots = new List<GameObject>();


    // Use this for initialization
    void Start()
    {

        webShots = new List<GameObject>();
        StartCoroutine(SpawnWebs(startingDelay));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float direction = -offSet.x;
        // direction = direction.normalized;
        foreach (GameObject g in webShots)
        { 
            if(g!=null)
                g.GetComponent<Rigidbody2D>().velocity = new Vector3(direction, 0, 0) * Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
        }
            
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            player.rigidbody2D.AddForce(new Vector2(0, 0));
            counter++;

            if (counter == 4)
            {
                player.rigidbody2D.AddForce(new Vector2(3, 3));
            }

        }
    }

    private IEnumerator SpawnWebs(float s)
    {
        yield return new WaitForSeconds(s);

        if (limit >= 0)
        {
            webShots.Add((GameObject)Instantiate(webShotPrefab, new Vector3(offSet.x, Random.Range(-offSet.y, offSet.y), offSet.z), Quaternion.identity));
            limit--;
            StartCoroutine(SpawnWebs(Random.Range(delayMin, delayMax)));
        }
    }

}
