using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 10) * 10;
	}
	
	void Update () {
		
	}
}
