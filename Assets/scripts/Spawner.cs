using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Ball;
    public bool GameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn()
    {
        if (GameOver == true)
        {
            //Spiel vorbei 
            Debug.Log("Spiel Vorbei");
        } else
        {
            GameObject [] test = GameObject.FindGameObjectsWithTag("Ball");

            if (test.Length > 1)
            {

            } else
            {
                Instantiate(Ball, transform.position, Quaternion.identity);
            }


        }

    }

    public void ExtraBall()
    {
        Instantiate(Ball, transform.position, Quaternion.identity);
    }
}
