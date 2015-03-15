using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float minZoom = 1.0f;
    public float maxZoom = 3.5f;
    public GameObject player;

    private void Update()
    {
        if (player != null)
        {

            transform.position = Vector3.Slerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), Time.deltaTime * 2);
           // GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, Mathf.Clamp(player.GetComponent<Rigidbody2D>().velocity.magnitude, minZoom, maxZoom), Time.deltaTime);
        }
    }
}