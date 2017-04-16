using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text punkte;
    public int SP1 = 0;
    public int SP2 = 0;


	// Use this for initialization
	void Start () {
        punkte.text = SP1 + " - " + SP2 ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore()
    {
        punkte.text = SP1 + "   " + SP2;
    }
}
