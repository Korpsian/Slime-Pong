﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour {

    Animator anim;
    AudioSource audio;
    public AudioClip[] Soundeffekte;
    private GameObject Manager;
    private GameObject Spawner;

	void Start () {
        

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5,5), Random.Range(-5, 5)) * 7;

        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        Manager = GameObject.Find("Score Manager");
        Spawner = GameObject.Find("Spawner");
    }
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PointSP1")
        {
            Manager.GetComponent<ScoreManager>().SP1 = Manager.GetComponent<ScoreManager>().SP1 + 1;
            Manager.GetComponent<ScoreManager>().UpdateScore();
        }


        if (col.gameObject.tag == "PointSP2")
        {
            Debug.Log("PointSP2");
            Manager.GetComponent<ScoreManager>().SP2 = Manager.GetComponent<ScoreManager>().SP2 + 1;
            Manager.GetComponent<ScoreManager>().UpdateScore();
        }

        Spawner.GetComponent<Spawner>().Spawn();

        Destroy(this);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("kollision", true);

       

        //Wähle Zufälligen Soundeffekt und spiele ihn ab
        int i = Random.Range(0, 2);
        PlaySound(i);
    }

    void PlaySound (int i)
    {
        audio.Play();
    }

}
