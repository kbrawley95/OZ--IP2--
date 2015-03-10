using UnityEngine;
using System.Collections;

public class RockPlacement : MonoBehaviour {

    private Invisible invisible;

    void Start()
    {
        invisible = GetComponent<Invisible>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
            if (target.gameObject.tag == "Block")
            {
                Destroy(target.gameObject);
                invisible.isVisible = true;
            }

    }

    void Update()
    {
       

    }

   


}
