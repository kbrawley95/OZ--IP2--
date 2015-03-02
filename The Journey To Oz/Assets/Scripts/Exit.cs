using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{

    // Use this for initialization


    private bool exitScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !exitScene)
        {
            Application.Quit();
        }

    }
}

    
