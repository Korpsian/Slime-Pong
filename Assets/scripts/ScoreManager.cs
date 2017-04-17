using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text punkte;
    public int SP1 = 0;
    public int SP2 = 0;

    GameObject Spieler1;
    GameObject Spieler2;
    GameObject Spawner;


	// Use this for initialization
	void Start () {
        punkte.text = SP1 + "   " + SP2 ;

        Spieler1 = GameObject.FindGameObjectWithTag("SP1");
        Spieler2 = GameObject.FindGameObjectWithTag("SP2");
        Spawner = GameObject.FindGameObjectWithTag("Spawner");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void UpdateScore()
    {

        if (SP1 == 7)
        {
            Spawner.GetComponent<Spawner>().GameOver = true;
            punkte.text = ("Player 1 Wins!");
        }
        else if (SP2 == 7)
        {
            Spawner.GetComponent<Spawner>().GameOver = true;
            punkte.text = ("Player 2 Wins!");
        } else
        {
            punkte.text = SP1 + "   " + SP2;

            Spieler1.GetComponent<PlayerMovement>().JumpBack();
            Spieler2.GetComponent<PlayerMovement>().JumpBack();
        }

        Spawner.GetComponent<Spawner>().Spawn();

    }
}
