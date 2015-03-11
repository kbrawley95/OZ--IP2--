using UnityEngine;
using System.Collections;

public class RockPlacement : MonoBehaviour {

    public GameObject rock;
    public GameObject collisionRock;
    private DisableCollider collider;

    void Start()
    {
        collider = GetComponent<DisableCollider>();
        rock.renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.gameObject== collisionRock)
        {
            Destroy(target.gameObject);
            rock.renderer.enabled = true;
            collider.RockCounter++;
        }
       

    }

    void Update()
    {
       

    }

   


}
