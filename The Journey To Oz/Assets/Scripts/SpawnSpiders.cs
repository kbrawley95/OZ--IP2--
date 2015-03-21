using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSpiders : MonoBehaviour {

    public GameObject spiderPrefab;
    public Vector3 offset = Vector3.zero;
    public float startingDelay = 1.0f;
    public float delay = 2.0f;
    private int limit = 50;

    private List<GameObject> spiders = new List<GameObject>();

    private void Start()
    {
        spiders = new List<GameObject>();
        StartCoroutine(SpawnASpiders(startingDelay));
    }

    private IEnumerator SpawnASpiders(float s)
    {
        yield return new WaitForSeconds(s);

        if (limit >= 0)
        {
            spiders.Add((GameObject)Instantiate(spiderPrefab, new Vector3(offset.x, Random.Range(-offset.y, offset.y), offset.z), Quaternion.identity));
            limit--;
            StartCoroutine(SpawnASpiders(delay));
        }
    }


   

   


}
