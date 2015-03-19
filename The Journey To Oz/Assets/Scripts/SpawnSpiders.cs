using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSpiders : MonoBehaviour {

    public List<GameObject> spiders;

    public GameObject spawnObject;
    public GameObject player;
    public float x;
    public float y;
    public float z;
    public float spawnRate;
    public float initialDelay;
    public int limit = 7;
    private float counter;



    void Start()
    {
        spiders = new List<GameObject>();
    }


    void Update()
    {
        InvokeRepeating("Spawn",initialDelay, spawnRate);
       

        if (spiders.Count == limit)
        {
            CancelInvoke("Spawn");

        }
      
    }

    void Spawn()
    {
        spiders.Add((GameObject)Instantiate(spawnObject, new Vector3(x, Random.Range(-y, y), z), Quaternion.identity));
        
    }   

   

   


}
