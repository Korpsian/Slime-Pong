using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 5) * 5;
	}
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

}
