using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour {

    public float StartSpeed = 10;
    [Range(0, 1)]
    public float StartYMovementRange = 0.5f;
    public AudioClip[] Soundeffekte;

    Animator anim;
    AudioSource audio;

    private GameObject PowerupSpawner;
    private GameObject Manager;
    private GameObject Spawner;
    private Rigidbody2D phys;
    private int BounceCounter = 0;

	void Start () {
        phys = gameObject.GetComponent<Rigidbody2D>();
        Vector2 StartDirection = new Vector2(1,0);

        if (Random.value > 0.5f)
        {
            StartDirection *= -1;
        }

        StartDirection += new Vector2(0, Random.Range(-StartYMovementRange,StartYMovementRange));

        phys.velocity = StartDirection * StartSpeed;

        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        PowerupSpawner = GameObject.Find("SpawnArea");
        Manager = GameObject.Find("Score Manager");
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
    }
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PointSP1")
        {
            Manager.GetComponent<ScoreManager>().SP1 = Manager.GetComponent<ScoreManager>().SP1 + 1;
            Manager.GetComponent<ScoreManager>().UpdateScore();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "PointSP2")
        {
            Manager.GetComponent<ScoreManager>().SP2 = Manager.GetComponent<ScoreManager>().SP2 + 1;
            Manager.GetComponent<ScoreManager>().UpdateScore();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "PowerupGrößer")
        {
            Vector2 größe = transform.localScale;
            größe.x = größe.x + 0.5f;
            größe.y = größe.y + 0.5f;
            transform.localScale = größe;
        }

        if (col.gameObject.tag == "PowerupKleiner")
        {
            Vector2 größe = transform.localScale;
            größe.x = größe.x - 0.5f;
            größe.y = größe.y - 0.5f;
            transform.localScale = größe;
        }

        if (col.gameObject.tag == "PowerupSchneller")
        {
            phys.velocity *= 1.5f;
        }

        if (col.gameObject.tag == "PowerupExtraball")
        {
            Spawner.GetComponent<Spawner>().ExtraBall();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("kollision", true);

        phys.velocity /= (1 + BounceCounter/10);
        BounceCounter++;
        phys.velocity *= (1 + BounceCounter / 10);
        Debug.Log(BounceCounter);

        PowerupSpawner.GetComponent<PowerUpSpawner>().SpawnPowerup();

        //Wähle Zufälligen Soundeffekt und spiele ihn ab
        int i = Random.Range(0, 2);
        PlaySound(i);
    }

    void PlaySound (int i)
    {
        audio.Play();
    }

}
