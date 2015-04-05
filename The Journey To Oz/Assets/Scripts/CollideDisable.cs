using UnityEngine;
using System.Collections;

public class CollideDisable : MonoBehaviour {

    //Scripts
    CameraFollow cam;
    BossEnemyController controller;
    SpawnSpiders spiderSpawn;
    WebShot webSpawn;
    Animator anim;

    //Reference Objects
    public GameObject obj;
    public GameObject spider;
    public GameObject background;

    //Audio Components
    private AudioSource source;
    public AudioClip battleTheme;


	// Use this for initialization
	void Start () {

        
        cam = obj.GetComponent<CameraFollow>();

        controller=spider.GetComponent<BossEnemyController>();
        controller.enabled = false;

        spiderSpawn = spider.GetComponent<SpawnSpiders>();
        spiderSpawn.enabled = false;

        webSpawn = spider.GetComponent<WebShot>();
        webSpawn.enabled = false;

        source = background.GetComponent<AudioSource>();

        anim = spider.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            spiderSpawn.enabled = true;
            controller.enabled = true;
            source.audio.Stop();
            webSpawn.enabled = true;

            audio.Play();

            cam.maxZoom = 1;
            cam.minZoom = 6f;



            gameObject.collider2D.enabled = false;
            //cam.enabled = false;
        }
    }

    public void EndGame()
    {
        //Disables all active components
        spiderSpawn.enabled = false;
        controller.enabled = false;
        webSpawn.enabled = false;
        audio.Stop();
        anim.SetInteger("Death", 1);
        


    }

   /* public void PlayBattleTheme()
    {
        if (battleTheme)
        {
            AudioSource.PlayClipAtPoint(battleTheme, transform.position, .5f);

        }
    }*/
}

